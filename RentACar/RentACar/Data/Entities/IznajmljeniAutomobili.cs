using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RentACar.Data.Entities
{
    public class IznajmljeniAutomobili
    {
        [Key, Required]
        public int IdIznajmljenogAutomobila { get; set; }
        [Required]
        public int BrojDana { get; set; }
        [Required]
        public byte IsRazresen { get; set; }
        [Required]
        public int IdAutomobila { get; set; }
        public string IdKorisnika { get; set; }
        public byte IsDeleted { get; set; }
    }
}
