using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Parking_Lot.DB;
using Parking_Lot.Extensions;
using Parking_Lot.Models;

namespace Parking_Lot.Controllers
{
    public class EstacionamientoController : Controller
    {
        private AppDbContext context;
        public EstacionamientoController() {
            context = new AppDbContext();
        }

        public IActionResult Index()
        {
            var usserLogged = HttpContext.Session.Get<User>("SessionLoggedUser");
            var estacionamiento = context.Estacionamientos.ToList();
            ViewBag.Tarjeta = context.Tarjetas.Where(o => o.IdUser == usserLogged.Id).ToList();
            return View(estacionamiento);
        }
        [HttpPost]
        public IActionResult Reserva(Reserva reserva) 
        {
            var usserLogged = HttpContext.Session.Get<User>("SessionLoggedUser");
            reserva.IdUser = usserLogged.Id;
            context.Reservas.Add(reserva);
            context.SaveChanges();
            return RedirectToAction("Index","Menu");
        }
        public static DateTime Today { get; }
        [HttpPost]
        public IActionResult Pagar(Pago pago)
        {
            DateTime thisDay = DateTime.Today;
            var usserLogged = HttpContext.Session.Get<User>("SessionLoggedUser");
            pago.IdUser = usserLogged.Id;
            pago.Fecha = thisDay.ToString();
            if (pago.IdTarjeta==0 || pago.NHoras==0) {
                return RedirectToAction("Index", "Menu");
            }
            context.Pagos.Add(pago);
            context.SaveChanges();
            return RedirectToAction("Index", "Menu");
        }
    }
}