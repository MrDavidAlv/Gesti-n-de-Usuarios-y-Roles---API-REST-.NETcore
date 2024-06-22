// User.cs
using empleadosFYMtech.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


[Table("datosUsuario", Schema = "usuario")]
public class Usuario
{
    [Key]
    public int id { get; set; }

    [Required]
    [MaxLength(100)]
    public string nombres { get; set; }

    [Required]
    [MaxLength(100)]
    public string apellidos { get; set; }

    [Required]
    public int tipoDocumento { get; set; }

    [Required]
    public int documento { get; set; }

    public DateTime? fechaNacimiento { get; set; }

    [Required]
    [MaxLength(150)]
    public string email { get; set; }

    [Required]
    [MaxLength(250)]
    public string password { get; set; }

    public int? idCiudad { get; set; }

    public int? idPais { get; set; }

    public int? idRol { get; set; }

}
