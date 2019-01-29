using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Avtobuska.Models;

namespace Avtobuska.Models
{
    public class AvtobuskaContext : DbContext
    {
        public AvtobuskaContext (DbContextOptions<AvtobuskaContext> options)
            : base(options)
        {
        }

        public DbSet<Avtobuska.Models.Bilet> Bilet { get; set; }

        public DbSet<Avtobuska.Models.Linija> Linija { get; set; }

        public DbSet<Avtobuska.Models.Mesto> Mesto { get; set; }

        public DbSet<Avtobuska.Models.Stanica> Stanica { get; set; }

        public DbSet<Avtobuska.Models.Prevoznik> Prevoznik { get; set; }
    }
}
