using Microsoft.AspNetCore.Identity;

namespace RecapNewCore.Modules.User;

public class User: IdentityUser
{
    public string FirstName { get; set; }
    
    public string LastName { get; set; }
    
    public string Address { get; set; }
 
}

public class UserRequest
{
    public string FirstName { get; set; }
    
    public string LastName { get; set; }
    
    public string Email { get; set; }
    
    public string Address { get; set; }
    
    public string PhoneNumber { get; set; }
    
    public string Password { get; set; }   
}

public class UserResponse
{
    public string FirstName { get; set; }
    
    public string LastName { get; set; }
    
    public string Email { get; set; }
    
    public string Address { get; set; }
    
    public string PhoneNumber { get; set; }

}

public class UserLoginRequest
{
    public string Email { get; set; }

    public string Password { get; set; }
}

public class LoginResponse
{
    public string Token { get; set; }

    public UserResponse User { get; set; }
}
