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
    public class ImagenController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public ImagenController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _unitOfWork.ImagenRepository.GetAll();
            return Ok(result);
        }

        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [HttpGet]
        [Route("Pagination")]
        public async Task<IActionResult> GetPagination([FromQuery] ImagenPaginationFilterViewModel filter)
        {
            var result = await _unitOfWork.ImagenRepository.GetPagination(filter);
            return Ok(result);
        }

        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [HttpGet]
        [Route("PaginationId")]
        public async Task<IActionResult> GetPaginationId([FromQuery] ImagenPaginationFilterViewModel filter)
        {
            var result = await _unitOfWork.ImagenRepository.GetPaginationId(filter);
            return Ok(result);
        }

        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _unitOfWork.ImagenRepository.GetByID(id);
            return Ok(result);
        }

        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Imagen modelo)
        {
            var result = await _unitOfWork.ImagenRepository.Add(modelo);
            return result > default(int) ? Ok(result) : (IActionResult)BadRequest();
        }

        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Imagen modelo)
        {
            if (modelo.Id == default)
                throw new GuiaException("Debe ingresar un identificador");

            var result = await _unitOfWork.ImagenRepository.Update(modelo);
            return result ? Ok(result) : (IActionResult)BadRequest();
        }

        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _unitOfWork.ImagenRepository.Delete(new Imagen { Id = id });
            return result ? Ok(result) : (IActionResult)BadRequest();
        }
    }
}
