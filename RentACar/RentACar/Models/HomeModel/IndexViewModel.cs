﻿using RentACar.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentACar.Models
{
    public class IndexViewModel
    {
        public List<Automobil> Automobili { get; set; }
        public string Poruka { get; set; }
    }
}
