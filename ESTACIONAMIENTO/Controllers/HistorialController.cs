using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Parking_Lot.DB;
using Parking_Lot.Extensions;
using Parking_Lot.Models;

namespace Parking_Lot.Controllers
{
    public class HistorialController : Controller
    {
        private AppDbContext context;
        public HistorialController() 
        {
            context = new AppDbContext();
        }
        public IActionResult Index()
        {
            var usserLogged = HttpContext.Session.Get<User>("SessionLoggedUser");
            ViewBag.Reservas = context.Reservas.Where(o => o.IdUser == usserLogged.Id).ToList();
            ViewBag.Pagos = context.Pagos.Where(o => o.IdUser == usserLogged.Id).ToList();
            return View();
        }
    }
}