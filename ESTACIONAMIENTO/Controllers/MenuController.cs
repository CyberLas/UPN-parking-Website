using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Parking_Lot.DB;
using Parking_Lot.Models;

namespace Parking_Lot.Controllers
{
    [Authorize]
    public class MenuController : Controller
    {
        private AppDbContext context;
        public MenuController() {
            context = new AppDbContext();
        }
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }
    }
}