﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Avtobuska.Models
{
    public class Mesto
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        
    }
}
