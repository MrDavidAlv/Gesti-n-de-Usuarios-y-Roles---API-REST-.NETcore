using empleadosFYMtech.DTOs;
using empleadosFYMtech.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace empleadosFYMtech.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        [AllowAnonymous] // Permitir acceso anónimo para el registro
        public async Task<IActionResult> Register(UserRegisterDto userDto)
        {
            try
            {
                var user = await _userService.Register(userDto);
                return Ok(new { message = "User registered successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("login")]
        [AllowAnonymous] // Permitir acceso anónimo para el inicio de sesión
        public async Task<IActionResult> Login(UserLoginDto userDto)
        {
            try
            {
                var token = await _userService.Login(userDto);
                return Ok(new { token });
            }
            catch (Exception ex)
            {
                return Unauthorized(new { message = ex.Message });
            }
        }

        [HttpGet("userinfo")]
        [Authorize] // Requiere autenticación JWT
        public IActionResult UserInfo()
        {
            // Obtener el nombre de usuario del token JWT
            var username = User.Identity.Name;
            return Ok(new { username });
        }
    }
}
