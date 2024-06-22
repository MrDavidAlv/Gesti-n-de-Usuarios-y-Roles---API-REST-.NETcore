namespace empleadosFYMtech.DTOs
{
    public class CiudadResponseDto
    {
        public string idCiudad { get; set; }
        public string nombreCiudad { get; set; }

        public string idPais { get; set; }
    }

    public class PaisResponseDto
    {
        public string idPais { get; set; }
        public string nombrePais { get; set; }
    }
}
