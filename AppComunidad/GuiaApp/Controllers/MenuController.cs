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
    public class MenuController : Controller
    {
        private readonly IManagementServiceConsume _serviceConsume;

        public MenuController(IManagementServiceConsume serviceConsume)
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
            IEnumerable<MenuModel> listPadres = await ListarMenuPadres();
            ViewBag.ListaPadres = listPadres;
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
                IEnumerable<MenuModel> listPadres = await ListarMenuPadres();
                ViewBag.ListaPadres = listPadres;
                return View(menu);
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: Menu/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            IEnumerable<MenuModel> listPadres = await ListarMenuPadres();
            ViewBag.ListaPadres = listPadres;
            var response = await _serviceConsume.GetAsync<MenuModel>($"Menu/{id}", null);
            if (response.Success)
            {
               
                return View(response.Result);
            }
            return View(new MenuModel());
        }

        // POST: Menu/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(MenuModel menu)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var response = await _serviceConsume.PutAsync($"Menu", menu);
                    if (response.Success)
                    {
                        return RedirectToAction(nameof(Index));
                    }                }

                IEnumerable<MenuModel> listPadres = await ListarMenuPadres();
                ViewBag.ListaPadres = listPadres;
                return View(menu);
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // POST: Banco/Delete/5
        [HttpDelete]
        public async Task<JsonResult> Delete(int id)
        {
            try
            {

                var response = await _serviceConsume.DeleteAsync($"Menu?id={id}");
                return Json(response.Result);
            }
            catch (Exception ex)
            {
                return Json(false);
            }
        }

        [HttpGet]
        public async Task<JsonResult> Pagination(MenuFilter filter)
        {
            var response = await _serviceConsume.GetAsync<MenuPagination>($"Menu/Pagination?Start={filter.Start}&Rows={filter.Length}&Draw={filter.Draw}", null);
            if (response.Success)
            {
                response.Result.Draw = filter.Draw;
                return Json(response.Result);
            }

            return Json(new MenuPagination());
        }

        public async Task<IEnumerable<MenuModel>> ListarMenuPadres()
        {
            var response = await _serviceConsume.GetAsync<IEnumerable<MenuModel>>("Menu", null);
            if (response.Success)
            {
                return response.Result.Where(a => a.Padre == 0).OrderBy(m => m.Nombre).ToList();
            }
            return new List<MenuModel>();
        }
    }
}
