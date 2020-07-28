using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Parking_Lot.Models;

namespace Parking_Lot.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Principal()
        {
            return View();
        }
        public IActionResult Servicios()
        {
            return View();
        }
        public IActionResult Soporte()
        {
            return View();
        }
    }
}
