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
            categorias.ToList().ForEach(x=> { x.Filter = "."+x.Nombre; });
            negocioIndexModel.categorias = categorias;


            IEnumerable<NegocioModel> negociosall = null;
            negociosall = await GetNegocioAll();

            List<NegocioModel> negocios = new List<NegocioModel>();

            negociosall.ToList().ForEach( x => {
                var negocio = GetNegocio(new NegocioFilter { UsuarioId = x.UsuarioId });
                var redes = GetNegocioRedes(new NegocioFilter { UsuarioId = x.UsuarioId });
                negocios.Add(new NegocioModel { 
                    Nombre = negocio.Result.Nombre, Filter = negocio.Result.Categoria.ToLower(),Redes=redes.Result
                });
                negocioIndexModel.negocios = negocios; 
            });

            await Task.WhenAll();

            return View(negocioIndexModel);
        }


        public async Task<IEnumerable<CategoriaModel>> GetCategoriasAll()
        {
            var response = await _serviceConsume.GetAsync<IEnumerable<CategoriaModel>>("Categoria");
            return response.Result.OrderBy(x => x.Nombre);
        }

        public async Task<IEnumerable<NegocioModel>> GetNegocioAll()
        {
            var response = await _serviceConsume.GetAsync<IEnumerable<NegocioModel>>("Negocio");
            return response.Result.OrderBy(x => x.Descripcion);
        }

        public async Task<NegocioEstructuraModel> GetNegocio(NegocioFilter filter)
        {
            var response = await _serviceConsume.GetAsync<NegocioPagination>($"Negocio/NegocioUsuarioId?UsuarioId={filter.UsuarioId}", null);
            return response.Result.Data.FirstOrDefault();
        }

        public async Task<IEnumerable<NegocioEstructuraModel>> GetNegocioRedes(NegocioFilter filter)
        {
            var response = await _serviceConsume.GetAsync<NegocioPagination>($"Negocio/NegocioRedesUsuarioId?UsuarioId={filter.UsuarioId}", null);
            return response.Result.Data;
        }

    }
}
