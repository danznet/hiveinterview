using hive_interview.Data.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace hive_interview.Data
{
    public class LocationJsonRepository : ILocationRepository
    {
        private List<Location> _locations;

        public LocationJsonRepository()
        {
            LoadLocationsFromJson();
        }
        public IEnumerable<Location> GetAll()
        {
            return _locations;
        }

        public Location GetById(int id)
        {
            return _locations.FirstOrDefault(x => x.Id == id);
        }

        private void LoadLocationsFromJson()
        {
            var pathToSeedData = Path.Combine(Directory.GetCurrentDirectory(), "Data", "locations.json");
            this._locations = JsonConvert.DeserializeObject<List<Location>>(File.ReadAllText(pathToSeedData));
        }
    }
}
