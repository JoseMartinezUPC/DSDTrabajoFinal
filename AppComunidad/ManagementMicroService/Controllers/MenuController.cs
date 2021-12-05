﻿using Domain.Core;
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

namespace ManagementMicroService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public MenuController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _unitOfWork.MenuRepository.GetAll();
            return Ok(result);
        }

        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [HttpGet]
        [Route("Pagination")]
        public async Task<IActionResult> GetPagination([FromQuery] MenuPaginationFilterViewModel filter)
        {
            var result = await _unitOfWork.MenuRepository.GetPagination(filter);
            return Ok(result);
        }

        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _unitOfWork.MenuRepository.GetByID(id);
            return Ok(result);
        }

        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Menu modelo)
        {
            var result = await _unitOfWork.MenuRepository.Add(modelo);
            return result > default(int) ? Ok(result) : (IActionResult)BadRequest();
        }

        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Menu modelo)
        {
            if (modelo.Id == default)
                throw new GuiaException("Debe ingresar un identificador");

            var result = await _unitOfWork.MenuRepository.Update(modelo);
            return result ? Ok(result) : (IActionResult)BadRequest();
        }

        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _unitOfWork.MenuRepository.Delete(new Menu { Id = id });
            return result ? Ok(result) : (IActionResult)BadRequest();
        }
    }
}
