using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AMWEATHER_CORE.Model
{
    [Table(name: "User")]
    public class User
    {
        [Key]
        public String Email { get; set; }

        [Column(TypeName = "varchar(500)")]
        [Required]
        public String Nombre { get; set; }
        [Column(TypeName = "varchar(500)")]
        [Required]
        public String Apellido { get; set; }

        [Column(TypeName = "varchar(500)")]
        [Required]
        public String Password { get; set; }
    }
}
