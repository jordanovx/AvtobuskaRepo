using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Avtobuska.Models
{
    public class Stanica
    {
        [Key]
        public int ID { get; set; }

        public int MestoID { get; set; }
        public Mesto Mesto { get; set; }

        public int LinijaID { get; set; }
        public Linija Linija { get; set; }

        public decimal CenaNaEdenPravec { get; set; }
        public decimal CenaNaPovraten { get; set; }
    }
}
