using Microsoft.AspNetCore.Mvc;
using RecapNewCore.Modules;
using RecapNewCore.Modules.User;
using RecapNewCore.Service.UserService;

namespace RecapNewCore.Controllers.UserController;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly UserService _userService;

    public UserController(UserService userService)
    {
        _userService = userService;
    }

    [HttpPost("addUser")]
    public async Task<IActionResult> AddUser(UserRequest request)
    {
        var user = await _userService.AddUser(request);

        return Ok(user);
    }
    
    [HttpPost("login")]
    public async Task<IActionResult> Login(UserLoginRequest request)
    {
        var result = await _userService.Login(request);

        if (result == null)
        {
            return Unauthorized("Invalid email or password");
        }

        return Ok(result);
    }

    
}
