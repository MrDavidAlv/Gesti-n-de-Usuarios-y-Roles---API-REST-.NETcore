using empleadosFYMtech.Data;
using empleadosFYMtech.Interfaces.Repository;
using empleadosFYMtech.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace empleadosFYMtech.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<List<Usuario>> GetUsuariosAsync()
        {
            return await _context.Usuarios.ToListAsync();
        }

        public async Task<Usuario> GetUsuarioByIdAsync(int id)
        {
            return await _context.Usuarios.FindAsync(id);
        }

        public async Task<Usuario> CrearUsuarioAsync(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }

        public async Task<bool> ActualizarUsuarioAsync(int id, Usuario usuario)
        {
            var existingUsuario = await _context.Usuarios.FindAsync(id);
            if (existingUsuario == null)
            {
                return false;
            }

            existingUsuario.nombres = usuario.nombres;
            existingUsuario.apellidos = usuario.apellidos;
            existingUsuario.tipoDocumento = usuario.tipoDocumento;
            existingUsuario.documento = usuario.documento;
            existingUsuario.fechaNacimiento = usuario.fechaNacimiento;
            existingUsuario.email = usuario.email;
            existingUsuario.password = usuario.password;
            existingUsuario.idCiudad = usuario.idCiudad;
            existingUsuario.idPais = usuario.idPais;
            existingUsuario.idRol = usuario.idRol;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> EliminarUsuarioAsync(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return false;
            }

            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Usuario> GetUserByEmailAsync(string email)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(u => u.email == email);
        }
    }
}
