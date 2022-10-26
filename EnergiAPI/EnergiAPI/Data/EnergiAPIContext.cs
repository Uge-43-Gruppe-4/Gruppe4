using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EnergiAPI.Model;

namespace EnergiAPI.Data
{
    public class EnergiAPIContext : DbContext
    {
        public EnergiAPIContext (DbContextOptions<EnergiAPIContext> options)
            : base(options)
        {
        }

        public DbSet<EnergiAPI.Model.MeterUnit> MeterUnit { get; set; } = default!;
    }
}
