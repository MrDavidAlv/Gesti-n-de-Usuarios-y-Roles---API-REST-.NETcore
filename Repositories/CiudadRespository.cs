using empleadosFYMtech.Interfaces.Repository;
using empleadosFYMtech.Models;
using Microsoft.EntityFrameworkCore;
using empleadosFYMtech.Data;

namespace empleadosFYMtech.Repositories
{
    public class CiudadRepository : ICiudadRepository
    {
        private readonly ApplicationDbContext _context;

        public CiudadRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Ciudad>> GetAllAsync()
        {
            return await _context.Ciudades.ToListAsync();
        }

        public async Task<IEnumerable<Ciudad>> GetByPaisIdAsync(int idPais)
        {
            return await _context.Ciudades
                               .Where(c => c.IdPais == idPais)
                               .ToListAsync();
        }

        public async Task<Ciudad> GetByIdAsync(int id)
        {
            return await _context.Ciudades.FindAsync(id);
        }

        // Implementa otros métodos según necesites
    }
}
