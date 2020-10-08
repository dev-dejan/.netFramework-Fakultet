using RentACar.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RentACar.Models.Admin
{
    public class CreateViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "Lozinka mora imati 1 specijalni znak, 1 veliko slovo, 1 malo slovo i jedan broj. Lozinka mora biti duza od {0}", MinimumLength = 6)]
        public string Password { get; set; }
    }
}
