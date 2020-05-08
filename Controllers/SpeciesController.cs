﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Dopta.API.Domain.Models;
using Dopta.API.Domain.Services;
using Dopta.API.Resources;
using Dopta.API.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dopta.API.Controllers
{
    [Route("/api/[controller]")]
    public class SpeciesController : Controller
    {
        private readonly ISpecieService _specieService;
        private readonly IMapper _mapper;

        public SpeciesController(ISpecieService specieService, IMapper mapper)
        {
            _specieService = specieService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IEnumerable<SpecieResource>> GetAllAsync()
        {
            var species = await _specieService.ListAsync();
            var resources = _mapper
                .Map<IEnumerable<Specie>, IEnumerable<SpecieResource>>(species);
            return resources;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveSpecieResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var specie = _mapper.Map<SaveSpecieResource, Specie>(resource);
            var result = await _specieService.SaveAsync(specie);

            if (!result.Success)
                return BadRequest(result.Message);
            var specieResource = _mapper.Map<Specie, SpecieResource>(result.Specie);
            return Ok(specieResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult>PutASync(int id,[FromBody]SaveSpecieResource resource)
        {
            var specie = _mapper.Map<SaveSpecieResource, Specie>(resource);
            var result = await _specieService.UpdateAsync(id, specie);

            if (!result.Success)
                return BadRequest(result.Message);
            var specieResource = _mapper.Map<Specie, SpecieResource>(result.Specie);
            return Ok(specieResource);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteASync(int id)
        {
            var result = await _specieService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);
            var specieResource = _mapper.Map<Specie, SpecieResource>(result.Specie);
            return Ok(specieResource);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult>GetByIdAsync(int id)
        {
            var result = await _specieService.GetByIdAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);
            var specieResource = _mapper.Map<Specie, SpecieResource>(result.Specie);
            return Ok(specieResource);
        }
    }
}
