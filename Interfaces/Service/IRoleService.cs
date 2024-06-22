using empleadosFYMtech.Models;
using System.Threading.Tasks;

namespace empleadosFYMtech.Interfaces.Service
{
    public interface IRoleService
    {
        Task<Rol> GetRoleByNameAsync(string roleName);
    }
}
