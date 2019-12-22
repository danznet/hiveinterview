using hive_interview.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace hive_interview.Data
{
    public class HiveInterviewContext : DbContext
    {
        public HiveInterviewContext(DbContextOptions<HiveInterviewContext> options) : base(options)
        {
        }

        public DbSet<Location> Locations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var pathToSeedData = Path.Combine(Directory.GetCurrentDirectory(), "Data", "locations.json");
            var locations = JsonConvert.DeserializeObject<List<Location>>(File.ReadAllText(pathToSeedData));

            modelBuilder.Entity<Location>().HasData(locations);
        }
    }
}
