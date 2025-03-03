using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShipCreator1.Models;

namespace ShipCreator1.Data
{
    public class ShipCreator1Context : DbContext
    {
        public ShipCreator1Context (DbContextOptions<ShipCreator1Context> options)
            : base(options)
        {
        }

        public DbSet<ShipCreator1.Models.Ship> Ships { get; set; } = default!;
    }
}
