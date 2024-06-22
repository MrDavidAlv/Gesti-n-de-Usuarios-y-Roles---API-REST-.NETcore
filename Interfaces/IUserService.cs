using empleadosFYMtech.DTOs;

namespace empleadosFYMtech.Interfaces
{
    public interface IUserService
    {
        Task<User> Register(UserRegisterDto userDto);
        Task<string> Login(UserLoginDto userDto);
    }
}
