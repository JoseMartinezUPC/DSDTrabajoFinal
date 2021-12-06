using GuiaApp.Infraestructure.Service;
using GuiaApp.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace GuiaApp.Controllers
{
    public class NegociosController : Controller
    {
        private readonly IGuiaServiceConsume _serviceConsume;
        public NegociosController(IGuiaServiceConsume serviceConsume)
        {
            _serviceConsume = serviceConsume;
        }

        public async Task<IActionResult> Index()
        {
            NegocioIndexModel negocioIndexModel = new NegocioIndexModel();
            IEnumerable<CategoriaModel> categorias = null;
            categorias = await GetCategoriasAll();
            negocioIndexModel.categorias = categorias;
            List<NegocioModel> negocios = new List<NegocioModel>();
            negocios.Add(new NegocioModel {Nombre="Negocio 1", Filter= "prueba" });
            negocios.Add(new NegocioModel { Nombre = "Negocio 1", Filter = "prueba" });
            negocioIndexModel.negocios = negocios;
            return View(negocioIndexModel);
        }
        

        public async Task<IEnumerable<CategoriaModel>> GetCategoriasAll()
        {
            var response = await _serviceConsume.GetAsync<IEnumerable<CategoriaModel>>("Categoria");
            return response.Result.OrderBy(x=>x.Nombre);
        }
    }
}
