using Avtobuska.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Avtobuska.ViewModels
{
    public class IndexViewModel
    {
        public IndexViewModel()
        {
            Destinacija = new DestinacijaViewModel();
            Linija = new LinijaViewModel();
            Bilet = new Bilet();
        }
        public DestinacijaViewModel Destinacija { get; set; }
        public LinijaViewModel Linija { get; set; }

        public Bilet Bilet { get; set; }
    }
}
