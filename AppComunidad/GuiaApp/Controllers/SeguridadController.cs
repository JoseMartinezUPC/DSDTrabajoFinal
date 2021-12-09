using GuiaApp.Helper;
using GuiaApp.Infraestructure.Service;
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
        private readonly IGuiaServiceConsume _serviceConsume;
        private readonly IManagementServiceConsume _serviceConsumeM;

        public SeguridadController(IGuiaServiceConsume serviceConsume,IManagementServiceConsume serviceConsumeM)
        {
            _serviceConsume = serviceConsume;
            _serviceConsumeM = serviceConsumeM;
        }

        // GET: SeguridadController
        public ActionResult Login()
        {
            return View();
        }

        public async Task<IActionResult> Ingresar(LoginModel login)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var response = await _serviceConsumeM.GetAsync<UsuarioModel>($"Usuario/Acceso?Login={login.usuario}&Password={login.password}", null);
                    if (response.Result.Acceso)
                    {
                        var  usuario = response.Result;
                        HttpContext.Session.SetObjectAsJson("Usuario", usuario);
                        return RedirectToAction("Admin", "Home");
                    }
                    else 
                    {
                        ViewBag.Message = "Revise sus Credenciales";
                        ViewData["Message"] = "Revise sus Credenciales";
                        return View("Login");
                    }
                }
                return View("Login");
            }
            catch (Exception)
            {
                return View();
            }            
        }

        public async Task<IActionResult> Registro()
        {
            IEnumerable<TipoDocumentoModel> listTipoDocumento = await ListarTipoDocumentos();
            ViewBag.ListaDocumentos = listTipoDocumento;

            IEnumerable<TipoUsuarioModel> listTipoUsuario = await ListarTipoUsuarios();
            ViewBag.ListaUsuarios = listTipoUsuario;
            return View();
        }

        public ActionResult LogOff()
        {
            HttpContext.Session.SetObjectAsJson("Usuario", null);
            return RedirectToAction("Cliente", "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Registro(UsuarioModel usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var response = await _serviceConsume.PostAsync($"Usuario", usuario);
                    if (response.Success)
                    {
                        var response2 =  await _serviceConsume.GetAsync<UsuarioModel>($"Usuario/{response.Result}", null);
                        HttpContext.Session.SetString("CorreoUsuario", response2.Result.Correo);
                        return RedirectToAction("Mensaje", "Cliente");
                    }

                }
                IEnumerable<TipoDocumentoModel> listTipoDocumento = await ListarTipoDocumentos();
                ViewBag.ListaDocumentos = listTipoDocumento;

                IEnumerable<TipoUsuarioModel> listTipoUsuario = await ListarTipoUsuarios();
                ViewBag.ListaUsuarios = listTipoUsuario;
                return View(usuario);
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        public async Task<IEnumerable<TipoDocumentoModel>> ListarTipoDocumentos()
        {
            var response = await _serviceConsume.GetAsync<IEnumerable<TipoDocumentoModel>>("TipoDocumento");
            if (response.Success)
            {
                return response.Result.OrderBy(m => m.Descripcion).ToList();
            }
            return new List<TipoDocumentoModel>();
        }

        public async Task<IEnumerable<TipoUsuarioModel>> ListarTipoUsuarios()
        {
            var response = await _serviceConsume.GetAsync<IEnumerable<TipoUsuarioModel>>("TipoUsuario");
            if (response.Success)
            {
                return response.Result.OrderBy(m => m.Descripcion).ToList();
            }
            return new List<TipoUsuarioModel>();
        }

    }
}
