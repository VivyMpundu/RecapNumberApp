using Microsoft.AspNetCore.Identity;
using RecapNewCore.Data;
using RecapNewCore.Modules.User;

namespace RecapNewCore.Service.UserService;

public class UserService
{
    private readonly AppDbContext _context;
    private readonly UserManager<User> _userManager;
    
    private readonly TokenService _tokenService;

    public UserService(
        AppDbContext context,
        UserManager<User> userManager,
            TokenService tokenService)
    {
        _context = context;
        _userManager = userManager;
        _tokenService = tokenService;
    }

    public async Task<LoginResponse?> Login(UserLoginRequest request)
    {
        var user = await _userManager.FindByEmailAsync(request.Email);

        if (user == null)
        {
            return null;
        }

        var passwordCorrect = await _userManager.CheckPasswordAsync(
            user,
            request.Password
        );

        if (!passwordCorrect)
        {
            return null;
        }

        var token = _tokenService.GenerateToken(user);

        return new LoginResponse
        {
            Token = token,

            User = new UserResponse
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Address = user.Address,
                PhoneNumber = user.PhoneNumber
            }
        };
    }
public async Task<UserResponse> AddUser(UserRequest request)
{
    var userToCreate = new User
    {
        FirstName = request.FirstName,
        LastName = request.LastName,
        Email = request.Email,
        UserName = request.Email,
        Address = request.Address,
        PhoneNumber = request.PhoneNumber
    };

    var result = await _userManager.CreateAsync(
        userToCreate,
        request.Password
    );

    if (!result.Succeeded)
    {
        foreach (var error in result.Errors)
        {
            Console.WriteLine(error.Description);
        }

        throw new Exception("Failed to create user");
    }

    return new UserResponse
    {
        FirstName = userToCreate.FirstName,
        LastName = userToCreate.LastName,
        Email = userToCreate.Email,
        Address = userToCreate.Address,
        PhoneNumber = userToCreate.PhoneNumber
    };
}
}