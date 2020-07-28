    using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Parking_Lot.DB;
using Parking_Lot.Extensions;
using Parking_Lot.Models;

namespace Parking_Lot.Controllers
{
    public class TarjetaController : Controller
    {
        private AppDbContext context;
        public TarjetaController() {
            context = new AppDbContext();
        }
        public IActionResult Index()
        {
            var usserLogged = HttpContext.Session.Get<User>("SessionLoggedUser");

            var model = context.Tarjetas
                .Where(o => o.IdUser == usserLogged.Id)
                .ToList();
            return View(model);
        }
        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Crear(Tarjeta tarjeta)
        {
            var usserLogged = HttpContext.Session.Get<User>("SessionLoggedUser");

            tarjeta.IdUser = usserLogged.Id;
            context.Tarjetas.Add(tarjeta);
            context.SaveChanges();

            return RedirectToAction("Index","Menu");
        }
        [HttpPost]
        public IActionResult Borrar(int id)
        {
            var productoDb = context.Tarjetas.Where(o => o.Id == id).First();

            context.Tarjetas.Remove(productoDb);
            context.SaveChanges();

            return RedirectToAction("Final", "Inicio");
        }
    }
}