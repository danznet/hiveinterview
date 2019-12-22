using hive_interview.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace hive_interview.Data
{
    public class LocationSqlRepository : ILocationRepository
    {
        private readonly HiveInterviewContext _db;

        public LocationSqlRepository(HiveInterviewContext db)
        {
            _db = db;
        }

        public IEnumerable<Location> GetAll()
        {
            return _db.Locations;
        }

        public Location GetById(int id)
        {
            return _db.Locations.FirstOrDefault(x => x.Id == id);
        }
    }
}
