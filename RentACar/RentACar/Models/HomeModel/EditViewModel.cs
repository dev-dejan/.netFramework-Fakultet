using RentACar.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentACar.Models
{
    public class EditViewModel
    {
        public Osiguranje Osiguranje { get; set; }
        public List<Osiguranje> Osiguranjes { get; set; }
        public Automobil Automobil { get; set; }
    }
}
