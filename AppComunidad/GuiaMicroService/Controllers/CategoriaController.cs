using GuiaMicroService.Data;
using GuiaMicroService.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mime;
using System.Threading.Tasks;


namespace GuiaMicroService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : Controller
    {
        private readonly GuiaContext _context;

        public CategoriaController(GuiaContext context)
        {
            _context = context;
        }

        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [HttpGet]
        public IEnumerable<Categoria> GetAll()
        {
            return _context.Categoria.ToList();
        }
    }
}
