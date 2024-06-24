namespace empleadosFYMtech.DTOs.Response
{
    public class UserLoginResponseDto
    {
        public int id { get; set; }
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public string Email { get; set; }
        public int idRol { get; set; } // Id del rol al que se asignará el usuario
    }
}
