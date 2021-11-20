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
    public class BienController : Controller
    {
        private readonly GuiaContext _context;

        public BienController(GuiaContext context)
        {
            _context = context;
        }

        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [HttpGet]
        public IEnumerable<Bien> GetAll()
        {
            return _context.Bien.ToList();
        }
    }
}
