using RentACar.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentACar.Models
{
    public class PayViewModel
    {
        public int UkupnaCena { get; set; }
        public Automobil Automobil { get; set; }
        public IznajmljeniAutomobili IznajmljeniAutomobil { get; set; }
    }
}
