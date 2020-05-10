using AutoMapper;
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
    public class PetsController : Controller
    {
        private readonly IPetService _petService;
        private readonly IMapper _mapper;
        //
        public PetsController(IPetService petService, IMapper mapper)
        {
            _petService = petService;
            _mapper = mapper;

        }
        [HttpGet]
        public async Task<IEnumerable<PetResource>> GetAllAsync()
        {
            var pets = await _petService.ListAsync();
            var resources = _mapper
                .Map<IEnumerable<Pet>, IEnumerable<PetResource>>(pets);
            return resources;
        }
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SavePetResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var pet = _mapper.Map<SavePetResource, Pet>(resource);
            var result = await _petService.SaveAsync(pet);

            if (!result.Success)
                return BadRequest(result.Message);
            var petResource = _mapper.Map<Pet, PetResource>(result.Resource);
            return Ok(petResource);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> PutAsync(int id, [FromBody] SavePetResource resource)
        {
            var pet = _mapper.Map<SavePetResource, Pet>(resource);
            var result = await _petService.UpdateAsync(id, pet);

            if (!result.Success)
                return BadRequest(result.Message);
            var petResource = _mapper.Map<Pet, PetResource>(result.Resource);
            return Ok(petResource);

        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var result = await _petService.DeleteAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            var petResource = _mapper.Map<Pet, PetResource>(result.Resource);
            return Ok(petResource);
        }
    }
}
