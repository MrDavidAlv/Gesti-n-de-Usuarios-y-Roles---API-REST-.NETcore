using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace empleadosFYMtech.Models
{
    [Table("par", Schema = "ciudad")]
    public class Ciudad
    {
        [Key]
        public int idCiudad { get; set; }

        [Required]
        [MaxLength(100)]
        public string nombreCiudad { get; set; }

        [Required]
        public int idPais { get; set; }


    }

    [Table("par", Schema = "pais")]
    public class Pais
    {
        [Key]
        public int idPais { get; set; }

        [Required]
        [MaxLength(100)]
        public string nombrePais { get; set; }

    }
}
