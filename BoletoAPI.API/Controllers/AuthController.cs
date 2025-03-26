using BoletoAPI.API.Auth;
using Microsoft.AspNetCore.Mvc;

namespace BoletoAPI.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly TokenService _tokenService;
        
        public AuthController(TokenService tokenService)
        {
            _tokenService = tokenService;
        }
        
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModel model)
        {
            // For demo purposes, we're using a simple validation
            // In a real application, you would validate against a database
            if (model.Username == "admin" && model.Password == "admin")
            {
                var token = _tokenService.GenerateToken(model.Username);
                return Ok(new { token });
            }
            
            return Unauthorized();
        }
    }
    
    public class LoginModel
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}

