using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AMWEATHER_CORE.Model
{
    [Table(name: "WeatherAuditory")]
    public class WeatherAuditory
    {
        [Key]
        public int ID { get; set; }
        [Column(TypeName = "varchar(500)")]
        [Required]
        public String Email { get; set; }

        [Column(TypeName = "varchar(500)")]
        [Required]
        public String CountryCode { get; set; }
        [Column(TypeName = "varchar(500)")]
        [Required]
        public String CityCode { get; set; }
        [Column(TypeName = "varchar(500)")]
        [Required]
        public String Temperature { get; set; }
        [Column(TypeName = "varchar(500)")]
        [Required]
        public String Day { get; set; }

    }
}
