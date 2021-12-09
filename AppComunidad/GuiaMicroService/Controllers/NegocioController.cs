using Domain.Core;
using Domain.Entities;
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
    public class NegocioController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public NegocioController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _unitOfWork.NegocioRepository.GetAll();
            return Ok(result);
        }

        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _unitOfWork.NegocioRepository.GetByID(id);
            return Ok(result);
        }

        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Negocio modelo)
        {
            var result = await _unitOfWork.NegocioRepository.Add(modelo);
            return result > default(int) ? Ok(result) : (IActionResult)BadRequest();
        }

        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Negocio modelo)
        {
            if (modelo.Id == default)
                throw new GuiaException("Debe ingresar un identificador");

            var result = await _unitOfWork.NegocioRepository.Update(modelo);
            return result ? Ok(result) : (IActionResult)BadRequest();
        }

        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _unitOfWork.NegocioRepository.Delete(new Negocio { Id = id });
            return result ? Ok(result) : (IActionResult)BadRequest();
        }
    }
}
