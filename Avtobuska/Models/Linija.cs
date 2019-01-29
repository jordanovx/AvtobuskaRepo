using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Avtobuska.Models
{
    public class Linija
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }

        public DateTime VremeNaTrgnuvanje { get; set; }

        public int PrevoznikID { get; set; }
        public Prevoznik Prevoznik{ get; set; }

        List <Stanica> Stanica { get; set; }

        public int BrojNaSedista { get; set; }
        public int Peron { get; set; }

    }
}
