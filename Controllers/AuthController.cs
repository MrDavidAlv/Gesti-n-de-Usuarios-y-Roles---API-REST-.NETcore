using empleadosFYMtech.DTOs.Request;
using empleadosFYMtech.Interfaces.Service;
using empleadosFYMtech.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IAuthService _authService;

    public AuthController(IUserService userService, IAuthService authService)
    {
        _userService = userService;
        _authService = authService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] UserLoginRequestDto login)
    {
        var user = await _userService.GetUserByEmailAsync(login.Email);

        if (user == null)
        {
            return Unauthorized("Invalid email or password.");
        }

        bool isPasswordValid = await _userService.ValidatePasswordAsync(user, login.Password);

        if (!isPasswordValid)
        {
            return Unauthorized("Invalid email or password.");
        }

        var token = _authService.GenerateJwtToken(user);

        return Ok(new { Token = token });
    }
}
