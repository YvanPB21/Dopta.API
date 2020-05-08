using Microsoft.AspNetCore.Mvc;
using Dopta.API.Domain.Models;
using Dopta.API.Domain.Services;
using Dopta.API.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dopta.API.Extensions;
using AutoMapper;

namespace Dopta.API.Controllers
{
    [Route("api/[controller]")]
    public class CandidatesController : Controller 
    {
        private readonly ICandidateService _candidateService;
        private readonly IMapper _mapper;
        public CandidatesController(ICandidateService candidateService, IMapper mapper)
        {
            _candidateService = candidateService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IEnumerable<Candidate>> GetAllAsync()
        {
            var candidaters = await _candidateService.ListAsync();
            return candidaters;
        }
    }
}
