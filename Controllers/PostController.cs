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
    public class PostsController : Controller
    {
        private readonly IPostService _postService;
        private readonly IMapper _mapper;

        public PostsController(IPostService postService, IMapper mapper)
        {
            _postService = postService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IEnumerable<PostResource>> GetAllAsync()
        {
            var posts = await _postService.ListAsync();
            var resources = _mapper
                .Map<IEnumerable<Post>, IEnumerable<PostResource>>(posts);
            return resources;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SavePostResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var post = _mapper.Map<SavePostResource, Post>(resource);
            var result = await _postService.SaveAsync(post);

            if (!result.Success)
                return BadRequest(result.Message);
            var specieResource = _mapper.Map<Post, PostResource>(result.Resource);
            return Ok(specieResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutASync(int id, [FromBody]SavePostResource resource)
        {
            var post = _mapper.Map<SavePostResource, Post>(resource);
            var result = await _postService.UpdateAsync(id, post);

            if (!result.Success)
                return BadRequest(result.Message);
            var postResource = _mapper.Map<Post, PostResource>(result.Resource);
            return Ok(postResource);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteASync(int id)
        {
            var result = await _postService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);
            var specieResource = _mapper.Map<Post, PostResource>(result.Resource);
            return Ok(specieResource);
        }
    }
}
