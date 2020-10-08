using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RentACar.Data.Entities
{
    public class Automobil
    {
        [Key, Required]
        public int Id { get; set; }
        [Required]
        public string Marka { get; set; }
        [Required]
        public string Naziv { get; set; }
        [Required]
        public int Godina { get; set; }
        [Required]
        public int Cena { get; set; }
        [Required]
        public byte IsIznajmljeno { get; set; }
        [Required]
        public int IdOsiguranja { get; set; }
        public byte IsDeleted { get; set; }
    }
}
