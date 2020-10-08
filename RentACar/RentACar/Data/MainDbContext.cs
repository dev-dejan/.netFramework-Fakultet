using RentACar.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentACar.Data
{
    public class MainDbContext : DbContext
    {
        public MainDbContext(DbContextOptions<MainDbContext> options)
            : base(options)
        {
        }

        //MORAJU SE JEBENOOOIOOOOOOOO POKLAPATI IMENA OBJEKATA SA IMENIMA TABELA!!!!!!!!!!!!
        public DbSet<Automobil> Automobil { get; set; }
        public DbSet<Osiguranje> Osiguranje { get; set; }
        public DbSet<IznajmljeniAutomobili> IznajmljeniAutomobili { get; set; }
        public DbSet<Racun> Racun { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Role> Role { get; set; }
    }
}
