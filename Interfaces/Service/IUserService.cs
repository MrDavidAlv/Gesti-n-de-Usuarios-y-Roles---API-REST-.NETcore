using empleadosFYMtech.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace empleadosFYMtech.Interfaces.Service
{
    public interface IUserService
    {
        Task<List<Usuario>> GetUsuariosAsync();
        Task<Usuario> GetUsuarioByIdAsync(int id);
        Task<Usuario> CrearUsuarioAsync(Usuario usuario);
        Task<bool> ActualizarUsuarioAsync(int id, Usuario usuario);
        Task<bool> EliminarUsuarioAsync(int id);
        Task<Usuario> GetUserByEmailAsync(string email);
        Task<bool> ValidatePasswordAsync(Usuario user, string password);
    }
}

