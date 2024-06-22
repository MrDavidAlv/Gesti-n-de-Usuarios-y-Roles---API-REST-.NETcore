using empleadosFYMtech.Models;
using System.Threading.Tasks;

namespace empleadosFYMtech.Interfaces
{
    public interface IRoleService
    {
        Task<Role> GetRoleByNameAsync(string roleName);
    }
}
