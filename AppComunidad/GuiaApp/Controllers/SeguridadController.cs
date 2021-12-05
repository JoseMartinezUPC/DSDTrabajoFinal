using AppComunidad.Aplicativos.GuiaApp.Infraestructure.Service;
using GuiaApp.Models;
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
        private readonly IServiceConsume _serviceConsume;

        public SeguridadController(IServiceConsume serviceConsume)
        {
            _serviceConsume = serviceConsume;
        }

        // GET: SeguridadController
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Ingresar(string usuario,string password)
        {
            return RedirectToAction("Admin", "Home");
        }

        public async Task<IActionResult> Registro()
        {
            IEnumerable<TipoDocumentoModel> listTipoDocumento = await ListarTipoDocumentos();
            ViewBag.ListaDocumentos = listTipoDocumento;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Registro(UsuarioModel usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var response = await _serviceConsume.PostAsync($"Usuario", usuario, 1);
                    if (response.Success)
                    {
                        return RedirectToAction(nameof(Index));
                    }

                }
                IEnumerable<TipoDocumentoModel> listTipoDocumento = await ListarTipoDocumentos();
                ViewBag.ListaDocumentos = listTipoDocumento;
                return View(usuario);
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        public async Task<IEnumerable<TipoDocumentoModel>> ListarTipoDocumentos()
        {
            var response = await _serviceConsume.GetAsync<IEnumerable<TipoDocumentoModel>>("TipoDocumento",1);
            if (response.Success)
            {
                return response.Result.OrderBy(m => m.Descripcion).ToList();
            }
            return new List<TipoDocumentoModel>();
        }
    }
}
