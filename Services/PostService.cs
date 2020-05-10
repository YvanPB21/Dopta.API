using Dopta.API.Domain.Models;
using Dopta.API.Domain.Repositories;
using Dopta.API.Domain.Services;
using Dopta.API.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dopta.API.Services
{
    public class PostService : IPostService
    {
        private readonly ICandidateRepository _candidateRepository;
        private readonly IPostRepository _postRepository;
        public readonly IUnitOfWork _unitOfWork;

        public PostService(IPostRepository postRepository, IUnitOfWork unitOfWork)
        {
            _postRepository = postRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Post>> ListAsync()
        {
            return await _postRepository.ListAsync();
        }

        public async Task<PostResponse> SaveAsync(Post post)
        {
            try
            {
                await _postRepository.AddAsync(post);
                await _unitOfWork.CompleteAsync();

                return new PostResponse(post);
            }
            catch (Exception ex)
            {
                return new PostResponse($"An error ocurrred while saving the specie: { ex.Message }");
            }
        }

        public async Task<PostResponse> UpdateAsync(int id, Post post)
        {
            var existingPost = await _postRepository.FindById(id);
            if (existingPost == null)
                return new PostResponse("Post not found");
            existingPost.Description = post.Description; 
            try
            {
                _postRepository.Update(existingPost);
                await _unitOfWork.CompleteAsync();

                return new PostResponse(existingPost);
            }
            catch (Exception ex)
            {
                return new PostResponse($"An error ocurred while updating post: {ex.Message}");
            }
        }

        public async Task<PostResponse> DeleteAsync(int id)
        {
            var existingPost = await _postRepository.FindById(id);
            if (existingPost == null)
                return new PostResponse("Post not found");
            try
            {
                _postRepository.Remove(existingPost);
                await _unitOfWork.CompleteAsync();
                return new PostResponse(existingPost);
            }
            catch (Exception ex)
            {
                return new PostResponse($"An error ocurred while deleting post: {ex.Message}");
            }
        }

        public Task<IEnumerable<Post>> ListBySpecieIdAsync(int specieId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Post>> ListByCandidateIdAsync(int candidateId)
        {
            var postCandidates= await _candidateRepository.ListByCandidateIdAsync(candidateId);
            var products = postCandidates.Select(pt => pt.Post).ToList();
            return products;
        }
    }
}

