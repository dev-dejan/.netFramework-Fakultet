using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RentACar.Data.Entities
{
    public class Osiguranje
    {
        [Key, Required]
        public int IdOsiguranja { get; set; }
        [Required]
        public int Trajanje { get; set; }
        [Required]
        public string Tip { get; set; }
    }
}
