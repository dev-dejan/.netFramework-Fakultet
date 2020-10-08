using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RentACar.Data.Entities
{
    [Table("aspnetroles")]
    public class Role
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
