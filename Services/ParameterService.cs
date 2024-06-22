using empleadosFYMtech.Data;
using empleadosFYMtech.Interfaces.Service;
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
            return await _context.Paises.ToListAsync();
        }

        public async Task<IEnumerable<Ciudad>> GetCiudadesAsync()
        {
            return await _context.Ciudades.ToListAsync();
        }

        public async Task<IEnumerable<Ciudad>> GetCiudadesByPaisAsync(int idPais)
        {
            return await _context.Ciudades.Where(c => c.IdPais == idPais).ToListAsync();
        }
    }
}
