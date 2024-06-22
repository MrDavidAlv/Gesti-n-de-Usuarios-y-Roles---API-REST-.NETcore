using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace empleadosFYMtech.Models
{
    [Table("ciudad", Schema = "par")]
    public class Ciudad
    {
        [Key]
        public int IdCiudad { get; set; }

        [MaxLength(100)]
        public string NombreCiudad { get; set; }

        public int? IdPais { get; set; }

    }



    [Table("pais", Schema = "par")]
    public class Pais
    {
        [Key]
        public int IdPais { get; set; }

        [MaxLength(100)]
        public string nombrePais { get; set; }

    }
}
