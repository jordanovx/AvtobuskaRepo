using Avtobuska.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Avtobuska.ViewModels
{
    public class DestinacijaViewModel
    {
        public int MestoID { get; set; }
        public SelectList MestaList { get; set; }

    }
}
