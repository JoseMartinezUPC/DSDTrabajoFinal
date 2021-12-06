using Infraestructure.Repository.Queries;
using Infraestructure.UnitOfWork;
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
    public class UsuarioController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public UsuarioController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [HttpGet]
        [Route("Acceso")]
        public async Task<IActionResult> GetAcceso([FromQuery] UsuarioPaginationFilterViewModel filter)
        {
            var result = await _unitOfWork.UsuarioRepository.GetAcceso(filter);
            return Ok(result);
        }
    }
}
