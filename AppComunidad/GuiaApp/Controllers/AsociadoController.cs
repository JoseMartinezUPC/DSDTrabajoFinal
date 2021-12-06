using GuiaApp.Helper;
using GuiaApp.Infraestructure.Service;
using GuiaApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuiaApp.Controllers
{
    public class AsociadoController : Controller
    {
        private readonly IGuiaServiceConsume _serviceConsume;

        public AsociadoController(IGuiaServiceConsume serviceConsume)
        {
            _serviceConsume = serviceConsume;
        }

        public async Task<IActionResult> Modificar()
        {
            ModificarAsociadoModel asociadoModel = new ModificarAsociadoModel();
            asociadoModel.usuario = await ObtenerUsuario();
            IEnumerable<TipoDocumentoModel> listTipoDocumento = await ListarTipoDocumentos();
            ViewBag.ListaDocumentos = listTipoDocumento;
            IEnumerable<CategoriaModel> listCategorias = await GetCategoriasAll();
            ViewBag.ListaCategorias = listCategorias;
            return View(asociadoModel);
        }

        public async Task<UsuarioModel> ObtenerUsuario()
        {
            UsuarioModel usuario = new UsuarioModel();
            usuario = HttpContext.Session.GetObjectFromJson<UsuarioModel>("Usuario");
            var response = await _serviceConsume.GetAsync<UsuarioModel>($"Usuario/{usuario.Id}", null);
            return response.Result;
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

        public async Task<IEnumerable<CategoriaModel>> GetCategoriasAll()
        {
            var response = await _serviceConsume.GetAsync<IEnumerable<CategoriaModel>>("Categoria");
            return response.Result.OrderBy(x => x.Nombre);
        }
    }
}
