using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Parking_Lot.DB;
using Parking_Lot.Extensions;
using Parking_Lot.Models;

namespace Parking_Lot.Controllers
{
    public class UserController : Controller
    {
        private AppDbContext context;
        public UserController() {
            context = new AppDbContext();
        }
        [Authorize]
        public IActionResult Index()
        {
            var usserLogged = HttpContext.Session.Get<User>("SessionLoggedUser");
            return View(usserLogged);
        }
        [HttpGet]
        public IActionResult Registro()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Registro( User user)
        {
            var context = new AppDbContext();

            if (ModelState.IsValid)
            {
                context.Users.Add(user);
                context.SaveChanges();
                return RedirectToAction("Prueba");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(string email,string password)
        {
            var context = new AppDbContext();
            var user = context.Users.FirstOrDefault(o => o.Email == email && o.Password == password);

            if (user == null)
                return View();

            //Guarda en memoria cache
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, user.Email)
            };

            HttpContext.Session.Set("SessionLoggedUser", user);

            var userIdentity = new ClaimsIdentity(claims, "login");
            var principal = new ClaimsPrincipal(userIdentity);

            HttpContext.SignInAsync(principal);

            return RedirectToAction("Index", "Menu");
        }
        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public IActionResult Editar()
        {
            var usserLogged = HttpContext.Session.Get<User>("SessionLoggedUser");
            return View(usserLogged);
        }
        [HttpPost]
        public IActionResult Editar(User user)
        {
            var usserLogged = HttpContext.Session.Get<User>("SessionLoggedUser");
            var context = new AppDbContext();
            var usuario = context.Users.Where(o => o.Id == usserLogged.Id).First();

            usuario.FirstName = user.FirstName;
            usuario.LastName = user.LastName;
            usuario.Email = user.Email;
            usuario.Date = user.Date;
            usuario.Genero = user.Genero;
            context.SaveChanges();
            HttpContext.Session.Set("SessionLoggedUser", usuario);

            return RedirectToAction("Index", "Menu");
        }
    }
}