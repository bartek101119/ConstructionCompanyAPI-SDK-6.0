﻿using AutoMapper;
using constructionCompanyAPI.Entities;
using constructionCompanyAPI.Models;
using constructionCompanyAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace constructionCompanyAPI.Controllers
{
    [Route("/api/constructionCompany")]
    [ApiController]
    // disable authorization if you want to test faster
    [Authorize]
    public class ConstructionCompanyController : ControllerBase
    {
        private readonly IConstructionCompanyService service;

        public ConstructionCompanyController(IConstructionCompanyService service)
        {
            this.service = service;
        }

        [HttpPut("{id}")]
        public ActionResult Put([FromBody] UpdateConstructionCompanyDto dto, [FromRoute] int id)
        {
            service.Put(dto, id);

            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            service.Delete(id);

            return NoContent();

        }

        [HttpPost]
        [Authorize(Roles = "User")]
        public ActionResult CreateConstructionCompany([FromBody] CreateConstructionCompanyDto dto)
        {

            var id = service.Create(dto);

            return Created($"api/constructionCompany/{id}", null);
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult<IEnumerable<ConstructionCompanyDto>> GetAll([FromQuery] ConstructionCompanyQuery query)
        {
            var constructionCompaniesDtos = service.GetAll(query);

            return Ok(constructionCompaniesDtos);
        }

        [HttpGet("NoTracking")]
        [AllowAnonymous]
        public ActionResult<IEnumerable<ConstructionCompanyDto>> GetAllNoTracking()
        {
            var constructionCompaniesDtos = service.GetAllWithoutTracking();

            return Ok(constructionCompaniesDtos);

        }
        [HttpGet("{id}")]
        [Authorize(Policy = "AtLeast18")]
        public ActionResult<ConstructionCompanyDto> Get([FromRoute] int id)
        {
            var constructionCompanyDto = service.GetById(id);

            return Ok(constructionCompanyDto);
        }

    }
} 
