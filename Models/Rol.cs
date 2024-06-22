using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace empleadosFYMtech.Models
{
    [Table("roles", Schema = "par")]
    public class Rol
    {
        [Key]
        public int idRol { get; set; }

        [Required]
        [MaxLength(100)]
        public string nombreRol { get; set; }
    }

}
