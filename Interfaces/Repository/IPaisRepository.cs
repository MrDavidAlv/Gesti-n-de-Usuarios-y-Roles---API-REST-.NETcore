using System.Collections.Generic;
using System.Threading.Tasks;
using empleadosFYMtech.Models;

namespace empleadosFYMtech.Interfaces.Repository
{
    public interface IPaisRepository
    {
        Task<IEnumerable<Pais>> GetAllAsync();
        Task<Pais> GetByIdAsync(int id);
    }
}
