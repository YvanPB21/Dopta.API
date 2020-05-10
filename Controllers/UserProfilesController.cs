using AutoMapper;
using Dopta.API.Domain.Models;
using Dopta.API.Domain.Services;
using Dopta.API.Extensions;
using Dopta.API.Resources;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dopta.API.Controllers
{
    [Route("api/[controller]")]
    public class UserProfilesController : Controller
    {
        private readonly IUserProfileService _userProfileService;
        private readonly IMapper _mapper;
        public UserProfilesController(IUserProfileService userProfileService, IMapper mapper)
        {
            _userProfileService = userProfileService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IEnumerable<UserProfileResource>> GetAllAsync()
        {
            var userProfiles = await _userProfileService.ListAsync();
            var resources = _mapper
                .Map<IEnumerable<UserProfile>, IEnumerable<UserProfileResource>>(userProfiles);
            return resources;
        }
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveUserProfileResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var userProfile = _mapper.Map<SaveUserProfileResource, UserProfile>(resource);
            var result = await _userProfileService.SaveAsync(userProfile);
            if (!result.Success)
                return BadRequest(result.Message);
            var userProfileResource = _mapper.Map<UserProfile, UserProfileResource>(result.Resource);
            return Ok(userProfileResource);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutASync(int id, [FromBody]SaveUserProfileResource resource)
        {
            var userProfile = _mapper.Map<SaveUserProfileResource, UserProfile>(resource);
            var result = await _userProfileService.UpdateAsync(id, userProfile);

            if (!result.Success)
                return BadRequest(result.Message);
            var userProfileResource = _mapper.Map<UserProfile, UserProfileResource>(result.Resource);
            return Ok(userProfileResource);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteASync(int id)
        {
            var result = await _userProfileService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);
            var userProfileResource = _mapper.Map<UserProfile, UserProfileResource>(result.Resource);
            return Ok(userProfileResource);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var result = await _userProfileService.GetByIdAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);
            var userProfileResource = _mapper.Map<UserProfile, UserProfileResource>(result.Resource);
            return Ok(userProfileResource);
        }
    }
}
