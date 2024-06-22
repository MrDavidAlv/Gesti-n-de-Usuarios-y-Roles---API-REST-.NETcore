﻿using empleadosFYMtech.Data;
using empleadosFYMtech.Interfaces.Service;
using empleadosFYMtech.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace empleadosFYMtech.Services
{
    public class RoleService : IRoleService
    {
        private readonly ApplicationDbContext _context;

        public RoleService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Rol> GetRoleByNameAsync(string roleName)
        {
            return await _context.Roles.FirstOrDefaultAsync(r => r.nombreRol == roleName);
        }
    }
}
