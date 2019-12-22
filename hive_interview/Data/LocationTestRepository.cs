using hive_interview.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hive_interview.Data
{
    public class LocationTestRepository : ILocationRepository
    {
        private List<Location> _locations = new List<Location>()
        {
            new Location() { Id = 1, Description = "Test location 1", Postcode = "BS32 4SY", Latitude = 51.542534, Longitude = -2.571012},
            new Location() { Id = 2, Description = "Test location 2", Postcode = "BS32 8AD", Latitude = 51.52322559, Longitude = -2.547060374},
            new Location() { Id = 3, Description = "", Postcode = "BS32 4BX", Latitude = 51.54699048, Longitude = -2.595007376},
            new Location() { Id = 4, Description = "Test location 3", Postcode = "BS32 8EE", Latitude = 51.52971929, Longitude = -2.54859422}
        };

        public IEnumerable<Location> GetAll()
        {
            return _locations;
        }

        public Location GetById(int id)
        {
            return _locations.FirstOrDefault(x => x.Id == id);
        }
    }
}
