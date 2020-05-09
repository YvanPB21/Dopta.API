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
    [Route("/api/posts/{postId}/candidates")]
    public class CandidatesController : Controller
    {
        private readonly IUserService _userService;
        private readonly ICandidateService _candidateService;
        private readonly IMapper _mapper;

        public CandidatesController(IUserService userService, ICandidateService candidateService, IMapper mapper)
        {
            _candidateService = candidateService;
            _userService = userService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IEnumerable<UserResource>> GetAllByProductIdAsync(int postId)
        {
            var users = await _userService.ListByPostIdAsync(postId);
            var resources = _mapper
                .Map<IEnumerable<User>, IEnumerable<UserResource>>(users);
            return resources;
        }
        [HttpPost("{candidateId}")]
        public async Task<IActionResult> AssignCandidate(int postId, int candidateId)
        {

            var result = await _candidateService.AssignCandidateAsync(postId, candidateId);
            if (!result.Success)
                return BadRequest(result.Message);

            var userResource = _mapper.Map<User, UserResource>(result.Resource.User);
            return Ok(userResource);

        }
    }
}
