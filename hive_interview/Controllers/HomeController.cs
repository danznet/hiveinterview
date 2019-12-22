using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using hive_interview.Models;
using hive_interview.Data;
using Microsoft.Extensions.Options;

namespace hive_interview.Controllers
{
    public class HomeController : Controller
    {
        private readonly IOptions<ConfigModel> _conf;
        private readonly ILocationRepository _locationRepo;

        public HomeController(IOptions<ConfigModel> conf, ILocationRepository locationRepo)
        {
            _conf = conf;
            _locationRepo = locationRepo;
        }

        public IActionResult Index()
        {
            var locations = _locationRepo.GetAll();

            var model = new HomeViewModel()
            {
                Locations = locations.ToList(),
                LimitLocationRows = _conf.Value.LimitLocationRows
            };

            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
