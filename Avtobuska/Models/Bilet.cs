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
        public bool Povraten { get; set; }
        public Stanica Destinacija { get; set; }
        public DateTime DatumNaKupuvanje { get; set; }
        public DateTime DatumNaVazenje { get; set; }
        public decimal Cena { get; set; }
        public int DestinacijaID { get; internal set; }
    }
}
