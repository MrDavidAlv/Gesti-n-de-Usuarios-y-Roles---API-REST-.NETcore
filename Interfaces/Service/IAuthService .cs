namespace empleadosFYMtech.Interfaces.Service
{
    public interface IAuthService
    {
        string GenerateJwtToken(Usuario user);
    }
}
