namespace empleadosFYMtech.DTOs
{
    public class UserRegisterDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int RoleId { get; set; } // Id del rol al que se asignará el usuario
    }
}
