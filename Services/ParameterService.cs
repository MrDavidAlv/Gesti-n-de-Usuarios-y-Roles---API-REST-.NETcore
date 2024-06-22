using empleadosFYMtech.Data;
using empleadosFYMtech.Interfaces;
using empleadosFYMtech.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace empleadosFYMtech.Services
{
    public class ParametersService : IParametersService
    {
        private readonly ApplicationDbContext _context;

        public ParametersService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Pais>> GetPaisesAsync()
        {
            return await _context.Pais.ToListAsync();
        }

        public async Task<IEnumerable<Ciudad>> GetCiudadesAsync()
        {
            return await _context.Ciudad.ToListAsync();
        }

        public async Task<IEnumerable<Ciudad>> GetCiudadesByPaisAsync(int idPais)
        {
            return await _context.Ciudad.Where(c => c.idPais == idPais).ToListAsync();
        }
    }
}
