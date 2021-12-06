using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuiaApp.Controllers
{
    public class ClienteController : Controller
    {
        public IActionResult Mensaje()
        {
            ViewBag.Correo = HttpContext.Session.GetString("CorreoUsuario");
            return View();
        }
    }
}
