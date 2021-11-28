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
        string Baseurl = "https://localhost:44393/";
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
            List<CategoriaModel> categorias = new List<CategoriaModel>();
            using (var client = new HttpClient())
            {
                //Passing service base url
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                //Define request data format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient
                HttpResponseMessage Res = await client.GetAsync("api/Categoria");
                //Checking the response is successful or not which is sent using HttpClient
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api
                    var CategoriasResponse = Res.Content.ReadAsStringAsync().Result;
                    //Deserializing the response recieved from web api and storing into the Employee list
                    categorias = JsonConvert.DeserializeObject<List<CategoriaModel>>(CategoriasResponse);
                }
                //returning the employee list to view
                return categorias.OrderBy(x=> x.CategoriaNombre);
            }
        }
    }
}
