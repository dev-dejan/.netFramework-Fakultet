using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RentACar.Data.Entities
{
    public class Racun
    {
        [Key, Required]
        public int Id { get; set; }
        public int UkupnaCena { get; set; }
        [Required]
        public int IdIznajmljenogAutomobila { get; set; }
    }
}
