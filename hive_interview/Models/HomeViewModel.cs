using hive_interview.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hive_interview.Models
{
    public class HomeViewModel
    {
        public List<Location> Locations { get; set; }
        public int LimitLocationRows { get; set; }
    }
}