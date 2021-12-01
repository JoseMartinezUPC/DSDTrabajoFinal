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
    public class MenuController : Controller
    {
        private readonly IServiceConsume _serviceConsume;

        public MenuController(IServiceConsume serviceConsume)
        {
            _serviceConsume = serviceConsume;
        }
        // GET: MenuController
        public ActionResult Index()
        {
            return View();
        }

        // GET: Menu/Create
        public async Task<IActionResult> Create()
        {
            //IEnumerable<PaisModel> listPais = await ListarPais();
            //ViewBag.ListaPaises = listPais;
            return View();
        }

        // POST: Menu/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MenuModel menu)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var response = await _serviceConsume.PostAsync($"Menu", menu);
                    if (response.Success)
                    {
                        return RedirectToAction(nameof(Index));
                    }

                }
                //IEnumerable<PaisModel> listPais = await ListarPais();
                //ViewBag.ListaPaises = listPais;
                return View(menu);
            }
            catch (Exception ex)
            { 
                return View();
            }
        }


        [HttpGet]
        public async Task<JsonResult> Pagination(MenuFilter filter)
        {
            var response = await _serviceConsume.GetAsync<MenuPagination>($"Menu/Pagination?Start={filter.Start}&Rows={filter.Length}&Draw={filter.Draw}");
            if (response.Success)
            {
                response.Result.Draw = filter.Draw;
                return Json(response.Result);
            }

            return Json(new MenuPagination());
        }

    }
}
