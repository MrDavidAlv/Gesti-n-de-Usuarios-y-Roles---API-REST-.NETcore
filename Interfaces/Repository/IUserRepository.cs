using empleadosFYMtech.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace empleadosFYMtech.Interfaces.Repository
{
    public interface IUserRepository
    {
        Task<List<Usuario>> GetUsuariosAsync();
        Task<Usuario> GetUsuarioByIdAsync(int id);
        Task<Usuario> CrearUsuarioAsync(Usuario usuario);
        Task<bool> ActualizarUsuarioAsync(int id, Usuario usuario);
        Task<bool> EliminarUsuarioAsync(int id);
    }
}
