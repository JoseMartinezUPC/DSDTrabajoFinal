using GuiaApp.Helper;
using GuiaApp.Infraestructure.Service;
using GuiaApp.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace GuiaApp.Controllers
{
    public class AsociadoController : Controller
    {
        private readonly IGuiaServiceConsume _serviceConsume;
        private readonly IHostingEnvironment _environment;

        public AsociadoController(IGuiaServiceConsume serviceConsume, IHostingEnvironment iHostingEnvironment)
        {
            _serviceConsume = serviceConsume;
            _environment = iHostingEnvironment;
        }

        public async Task<IActionResult> Modificar()
        {
            ModificarAsociadoModel asociadoModel = new ModificarAsociadoModel();
            asociadoModel.Usuario = await ObtenerUsuario();
            IEnumerable<TipoDocumentoModel> listTipoDocumento = await ListarTipoDocumentos();
            ViewBag.ListaDocumentos = listTipoDocumento;
            IEnumerable<CategoriaModel> listCategorias = await GetCategoriasAll();
            ViewBag.ListaCategorias = listCategorias;
            IEnumerable<TipoImagenModel> listTipoImagenes = await ListarTipoImagenes();
            ViewBag.ListaTipoImagenes = listTipoImagenes;
            IEnumerable<TipoRedModel> listTipoRedes = await ListarTipoRedes();
            ViewBag.ListaTipoRedes = listTipoRedes;
            return View(asociadoModel);

        }

        [HttpGet]
        public async Task<JsonResult> PaginationImagen(ImagenFilter filter)
        {
            var response = await _serviceConsume.GetAsync<ImagenPagination>($"Imagen/PaginationId?Start={filter.Start}&Rows={filter.Length}&Draw={filter.Draw}&Id={filter.Id}", null);
            if (response.Success)
            {
                response.Result.Draw = filter.Draw;
                return Json(response.Result);
            }

            return Json(new ImagenPagination());
        }

        [HttpGet]
        public async Task<JsonResult> PaginationRed(RedFilter filter)
        {
            var response = await _serviceConsume.GetAsync<RedPagination>($"Red/PaginationId?Start={filter.Start}&Rows={filter.Length}&Draw={filter.Draw}&Id={filter.Id}", null);
            if (response.Success)
            {
                response.Result.Draw = filter.Draw;
                return Json(response.Result);
            }

            return Json(new RedPagination());
        }

        [HttpPost]
        public async Task<JsonResult> UploadImagen(int TipoImagenId, int IdUsuario, IFormFile file)
        {
            try
            {
                var newFileName = string.Empty;
                var fileName = string.Empty;
                string PathDB = string.Empty;
                ImagenModel imagen = new ImagenModel();

                if (file.Length > 0)
                {
                    //Getting FileName
                    fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');

                    //Assigning Unique Filename (Guid)
                    var myUniqueFileName = Convert.ToString(Guid.NewGuid());

                    //Getting file Extension
                    var FileExtension = Path.GetExtension(fileName);

                    // concating  FileName + FileExtension
                    newFileName = myUniqueFileName + FileExtension;

                    // Combines two strings into a path.
                    fileName = Path.Combine(_environment.WebRootPath, "Imagenes") + $@"\{newFileName}";

                    // if you want to store path of folder in database
                    PathDB = "Imagenes/" + newFileName;                    

                    imagen.Nombre = newFileName;
                    imagen.Ruta = PathDB;
                    imagen.TipoImagenId = TipoImagenId;
                    imagen.Extension = FileExtension;
                    imagen.UsuarioId = IdUsuario;
                }
                var response = await _serviceConsume.PostAsync($"Imagen", imagen);
                if (response.Success)
                {
                    using (FileStream fs = System.IO.File.Create(fileName))
                    {
                        file.CopyTo(fs);
                        fs.Flush();
                    }
                    return Json(new ImagenJson { Message = "Se registro Correctamente", Estado = true });
                }
                else 
                {
                    return Json(new ImagenJson { Message = "Error al Cargar Imagen", Estado = false });
                }
            }
            catch (Exception ex)
            {

                return Json(new ImagenJson { Message = ex.Message, Estado = false });
            }           
        }

        [HttpPost]
        public async Task<JsonResult> GuardarRed(int TipoRedId, int IdUsuario, string Recurso)
        {
            try
            {
                RedModel red = new RedModel();
                red.Recurso = Recurso;
                red.TipoRedId = TipoRedId;
                red.UsuarioId = IdUsuario;

                var response = await _serviceConsume.PostAsync($"Red", red);
                if (response.Success)
                {
                    return Json(new ImagenJson { Message = "Se registro Correctamente", Estado = true });
                }
                else
                {
                    return Json(new ImagenJson { Message = "Error al Cargar Imagen", Estado = false });
                }
            }
            catch (Exception ex)
            {

                return Json(new ImagenJson { Message = ex.Message, Estado = false });
            }
        }

            [HttpDelete]
        public async Task<JsonResult> DeleteImagen(int id)
        {
            try
            {

                var response = await _serviceConsume.DeleteAsync($"Imagen?id={id}");
                return Json(response.Result);
            }
            catch (Exception ex)
            {
                return Json(new ImagenJson { Estado = false, Message="Error" });
            }
        }

        [HttpDelete]
        public async Task<JsonResult> DeleteRed(int id)
        {
            try
            {

                var response = await _serviceConsume.DeleteAsync($"Red?id={id}");
                return Json(response.Result);
            }
            catch (Exception ex)
            {
                return Json(new ImagenJson { Estado = false, Message = "Error" });
            }
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

        public async Task<IEnumerable<TipoImagenModel>> ListarTipoImagenes()
        {
            var response = await _serviceConsume.GetAsync<IEnumerable<TipoImagenModel>>("TipoImagen");
            if (response.Success)
            {
                return response.Result.OrderBy(m => m.Descripcion).ToList();
            }
            return new List<TipoImagenModel>();
        }

        public async Task<IEnumerable<TipoRedModel>> ListarTipoRedes()
        {
            var response = await _serviceConsume.GetAsync<IEnumerable<TipoRedModel>>("TipoRed");
            if (response.Success)
            {
                return response.Result.OrderBy(m => m.Nombre).ToList();
            }
            return new List<TipoRedModel>();
        }
    }
}
