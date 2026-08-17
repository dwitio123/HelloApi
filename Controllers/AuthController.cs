using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    [HttpPost("login")]
    public IActionResult Login(LoginRequestDto request)
    {
        if (request.Username == "admin" && request.Password == "123456")
        {
            return Ok(new LoginResponseDto
            {
                Message = "Login berhasil",
                Username = request.Username
            });
        }

        return Unauthorized(new LoginResponseDto
        {
            Message = "Username atau password salah"
        });
    }
}