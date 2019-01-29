using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Avtobuska.Models
{
    public class Bilet
    {
        [Key]
        public int ID { get; set; }
        public int LinijaID { get; set; }
        public Linija Linija { get; set; }
        public int SedisteBroj { get; set; }
        
        public bool Izdaden { get; set; }
        public bool Rezerviran { get; set; } 
        public decimal Cena { get; set; }
    }
}
