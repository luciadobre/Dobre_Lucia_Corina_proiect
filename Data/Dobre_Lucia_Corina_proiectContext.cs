using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Dobre_Lucia_Corina_proiect.Models;

namespace Dobre_Lucia_Corina_proiect.Data
{
    public class Dobre_Lucia_Corina_proiectContext : DbContext
    {
        public Dobre_Lucia_Corina_proiectContext (DbContextOptions<Dobre_Lucia_Corina_proiectContext> options)
            : base(options)
        {
        }

        public DbSet<Dobre_Lucia_Corina_proiect.Models.Product> Product { get; set; } = default!;
        public DbSet<Dobre_Lucia_Corina_proiect.Models.Distributor> Distributor { get; set; } = default!;
    }
}
