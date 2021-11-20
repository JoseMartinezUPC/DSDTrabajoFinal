using ManagementMicroService.Data;
using ManagementMicroService.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mime;
using System.Threading.Tasks;

namespace ManagementMicroService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : Controller
    {
        private readonly ManagementContext _context;

        public MenuController(ManagementContext context)
        {
            _context = context;
        }

        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [HttpGet]
        public IEnumerable<Menu> GetAll()
        {           
            return _context.Menu.ToList();
        }
    }
}
