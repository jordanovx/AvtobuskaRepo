using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Avtobuska.ViewModels
{
    public class LinijaViewModel
    {
        public int MestoID { get; set; }
        public int LinijaID { get; set; }
        public SelectList Linii { get; set; }
        public bool Povraten { get; set; }
    }
}
