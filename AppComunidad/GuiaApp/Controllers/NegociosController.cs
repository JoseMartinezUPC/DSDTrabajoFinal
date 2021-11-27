using GuiaApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuiaApp.Controllers
{
    public class NegociosController : Controller
    {
        public IActionResult Index()
        {
            NegocioIndexModel negocioIndexModel = new NegocioIndexModel();
            List<CategoriaModel> categorias = new List<CategoriaModel>();
            categorias.Add(new CategoriaModel { CategoriaId = 1, CategoriaNombre = "Prueba",CategoriaFilter= ".prueba", CategoriaEstado = true });
            negocioIndexModel.categorias = categorias;
            List<NegocioModel> negocios = new List<NegocioModel>();
            negocios.Add(new NegocioModel {Nombre="Negocio 1", Filter= "prueba" });
            negocios.Add(new NegocioModel { Nombre = "Negocio 1", Filter = "prueba" });
            negocios.Add(new NegocioModel { Nombre = "Negocio 1", Filter = "prueba" });
            negocios.Add(new NegocioModel { Nombre = "Negocio 1", Filter = "prueba" });
            negocios.Add(new NegocioModel { Nombre = "Negocio 1", Filter = "prueba" });
            negocios.Add(new NegocioModel { Nombre = "Negocio 1", Filter = "prueba2" });
            negocios.Add(new NegocioModel { Nombre = "Negocio 1", Filter = "prueba2" });
            negocios.Add(new NegocioModel { Nombre = "Negocio 1", Filter = "prueba2" });
            negocios.Add(new NegocioModel { Nombre = "Negocio 1", Filter = "prueba2" });
            negocioIndexModel.negocios = negocios;
            return View(negocioIndexModel);
        }
    }
}
