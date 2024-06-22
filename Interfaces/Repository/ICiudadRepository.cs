
using System.Collections.Generic;
using System.Threading.Tasks;
using empleadosFYMtech.Models;
using global::empleadosFYMtech.Models;

namespace empleadosFYMtech.Interfaces.Repository
{
    public interface ICiudadRepository
    {
        Task<IEnumerable<Ciudad>> GetAllAsync();
        Task<IEnumerable<Ciudad>> GetByPaisIdAsync(int idPais);
        Task<Ciudad> GetByIdAsync(int id);
        // Otros métodos según sea necesario
    }
}

