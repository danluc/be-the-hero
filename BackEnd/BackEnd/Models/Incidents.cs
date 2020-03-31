using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Models
{
    public class Incidents
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double Value { get; set; }
        [ForeignKey("Ongs")]
        public string OngsId { get; set; }
        public virtual Ongs Ongs { get; set; }
    }
}
