using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AppRecibos.Models;

namespace AppRecibos.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Usuario usuario)
        {
            if (usuario.Nombre == "admin" && usuario.Contrasena == "12345")
                return RedirectToAction("Index", "Recibos");
            return View();
        }
    }
}
