using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuiaApp.Controllers
{
    public class SeguridadController : Controller
    {
        // GET: SeguridadController
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Ingresar(string usuario,string password)
        {
            return RedirectToAction("IndexCliente","Home");
        }

    }
}
