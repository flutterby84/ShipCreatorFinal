using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ShipCreator1.Data;
using ShipCreator1.Models;
using System;
using System.Linq;

namespace ShipCreator1.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ShipCreator1Context(
                       serviceProvider.GetRequiredService<DbContextOptions<ShipCreator1Context>>()))
            {
                // Look for any ships.
                if (!context.Database.CanConnect())

                {
                    context.Database.Migrate();
                }

                if (!context.Ships.Any()) 
                {
                    context.Ships.AddRange(
                        new Ship
                        {
                            ShipName = "Black Pearl", ShipType = "Brigantine", NauticalMilage = 5000,
                            PledgedFaction = "Pirates"
                        },
                        new Ship
                        {
                            ShipName = "Silent Mary", ShipType = "Galleon", NauticalMilage = 15000,
                            PledgedFaction = "Pirates"
                        },
                        new Ship
                        {
                            ShipName = "Flying Dutchman", ShipType = "Sloop", NauticalMilage = 8000,
                            PledgedFaction = "Explorers"
                        }
                    );

                    context.SaveChanges();
                }
            }
        }
    }
}