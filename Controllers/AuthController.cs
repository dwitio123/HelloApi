using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly JwtService _jwtService;

    public AuthController(JwtService jwtService)
    {
        _jwtService = jwtService;
    }

    [HttpPost("login")]
    public IActionResult Login(LoginRequestDto request)
    {
        if (request.Username == "admin" && request.Password == "123456")
        {
            var token = _jwtService.GenerateToken();
            return Ok(new LoginResponseDto
            {
                Message = "Login berhasil",
                Username = request.Username,
                Token = token
            });             
        }

        return Unauthorized(new LoginResponseDto
        {
            Message = "Username atau password salah"
        });
    }
}