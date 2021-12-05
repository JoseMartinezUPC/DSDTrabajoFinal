using Domain.Core;
using Domain.Entities;
using Infraestructure.Repository.Queries;
using Infraestructure.UnitOfWork;
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
        public async Task<IActionResult> GetAll()
        {
            var result = await _unitOfWork.UsuarioRepository.GetAll();
            return Ok(result);
        }

        //[Consumes(MediaTypeNames.Application.Json)]
        //[ProducesResponseType((int)HttpStatusCode.OK)]
        //[ProducesResponseType((int)HttpStatusCode.NotFound)]
        //[HttpGet]
        //[Route("Pagination")]
        //public async Task<IActionResult> GetPagination([FromQuery] UsuarioPaginationFilterViewModel filter)
        //{
        //    var result = await _unitOfWork.UsuarioRepository.GetPagination(filter);
        //    return Ok(result);
        //}

        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _unitOfWork.UsuarioRepository.GetByID(id);
            return Ok(result);
        }

        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Usuario modelo)
        {
            var result = await _unitOfWork.UsuarioRepository.Add(modelo);
            return result > default(int) ? Ok(result) : (IActionResult)BadRequest();
        }

        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Usuario modelo)
        {
            if (modelo.Id == default)
                throw new GuiaException("Debe ingresar un identificador");

            var result = await _unitOfWork.UsuarioRepository.Update(modelo);
            return result ? Ok(result) : (IActionResult)BadRequest();
        }

        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _unitOfWork.UsuarioRepository.Delete(new Usuario { Id = id });
            return result ? Ok(result) : (IActionResult)BadRequest();
        }
    }
}
