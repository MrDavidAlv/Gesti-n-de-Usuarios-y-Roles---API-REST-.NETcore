using empleadosFYMtech.Interfaces.Service;
using empleadosFYMtech.Interfaces.Repository;
using empleadosFYMtech.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace empleadosFYMtech.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }

        public async Task<List<Usuario>> GetUsuariosAsync()
        {
            return await _userRepository.GetUsuariosAsync();
        }

        public async Task<Usuario> GetUsuarioByIdAsync(int id)
        {
            return await _userRepository.GetUsuarioByIdAsync(id);
        }

        public async Task<Usuario> CrearUsuarioAsync(Usuario usuario)
        {
            return await _userRepository.CrearUsuarioAsync(usuario);
        }

        public async Task<bool> ActualizarUsuarioAsync(int id, Usuario usuario)
        {
            return await _userRepository.ActualizarUsuarioAsync(id, usuario);
        }

        public async Task<bool> EliminarUsuarioAsync(int id)
        {
            return await _userRepository.EliminarUsuarioAsync(id);
        }
    }
}
