using AutoMapper;
using Dopta.API.Domain.Models;
using Dopta.API.Domain.Services;
using Dopta.API.Resources;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dopta.API.Controllers
{
    [Route("/api/[controller]")]
    public class CandidateController : Controller
    {
        private readonly ICandidateService _candidateService;
        private readonly IMapper _mapper;

        public CandidateController(ICandidateService candidateService, IMapper mapper)
        {
            _candidateService = candidateService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IEnumerable<CandidateResource>> GetAllAsync()
        {
            var candidaters = await _candidateService.ListAsync();
            var resources = _mapper
                .Map<IEnumerable<Candidate>, IEnumerable<CandidateResource>>(candidaters);
            return resources;
        }
    }
}
