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
    public class VehiculosController : Controller
    {
        private AppDbContext context;
        public VehiculosController() {
            context = new AppDbContext();
        }
        public IActionResult Index()
        {
            var usserLogged = HttpContext.Session.Get<User>("SessionLoggedUser");
            var model = context.Vehiculos.Where(o => o.IdUser == usserLogged.Id).ToList();
            return View(model);
        }
        [HttpGet]
        public IActionResult Crear()
        {;
            return View();
        }

        [HttpPost]
        public IActionResult Crear(Vehiculo vehiculo)
        {
            var usserLogged = HttpContext.Session.Get<User>("SessionLoggedUser");

            vehiculo.IdUser = usserLogged.Id;
            context.Vehiculos.Add(vehiculo);
            context.SaveChanges();

            return RedirectToAction("Index");
        }
        [HttpGet]
        public ViewResult Editar(int id)
        {
            var vehiculo = context.Vehiculos.FirstOrDefault(o=>o.Id==id);
            return View(vehiculo);
        }

        [HttpPost]
        public RedirectToActionResult Editar(Vehiculo vehiculo)
        {
            var vehiculoDb = context.Vehiculos.FirstOrDefault(o=>o.Id==vehiculo.Id);

            vehiculoDb.Tipo = vehiculo.Tipo;
            vehiculoDb.Color = vehiculo.Color;
            vehiculoDb.Descripcion = vehiculo.Descripcion;
            vehiculoDb.Marca = vehiculo.Marca;
            vehiculoDb.Modelo = vehiculo.Modelo;
            context.SaveChanges();

            return RedirectToAction("Index","Menu");
        }
        [HttpGet]
        public IActionResult Borrar(int id)
        {
            var vehiculoDb = context.Vehiculos.FirstOrDefault(o=>o.Id==id);

            context.Vehiculos.Remove(vehiculoDb);
            context.SaveChanges();

            return RedirectToAction("Index", "Menu");
        }
    }
}