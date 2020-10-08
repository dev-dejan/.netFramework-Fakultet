using RentACar.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentACar.Models.Admin
{
    public class IndexViewModel
    {
        public List<User> Users { get; set; }
        public string Poruka { get; set; }
    }
}
