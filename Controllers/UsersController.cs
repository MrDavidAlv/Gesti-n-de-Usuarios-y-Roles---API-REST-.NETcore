using empleadosFYMtech.Interfaces.Service;
using empleadosFYMtech.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace empleadosFYMtech.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }

        [HttpGet]
        public async Task<ActionResult<List<Usuario>>> GetUsuarios()
        {
            try
            {
                var usuarios = await _userService.GetUsuariosAsync();
                if (usuarios == null || usuarios.Count == 0)
                {
                    return NotFound("No se encontraron usuarios.");
                }
                return Ok(usuarios);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetUsuario(int id)
        {
            try
            {
                var usuario = await _userService.GetUsuarioByIdAsync(id);
                if (usuario == null)
                {
                    return NotFound($"Usuario con ID {id} no encontrado.");
                }
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Usuario>> CrearUsuario(Usuario usuario)
        {
            try
            {
                var nuevoUsuario = await _userService.CrearUsuarioAsync(usuario);
                return CreatedAtAction(nameof(GetUsuario), new { id = nuevoUsuario.id }, nuevoUsuario);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarUsuario(int id, Usuario usuario)
        {
            try
            {
                var result = await _userService.ActualizarUsuarioAsync(id, usuario);
                if (!result)
                {
                    return NotFound($"Usuario con ID {id} no encontrado.");
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarUsuario(int id)
        {
            try
            {
                var result = await _userService.EliminarUsuarioAsync(id);
                if (!result)
                {
                    return NotFound($"Usuario con ID {id} no encontrado.");
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }
    }
}
