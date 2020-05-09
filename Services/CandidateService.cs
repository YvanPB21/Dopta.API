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
    public class CandidateService : ICandidateService
    {
        private readonly ICandidateRepository _candidateRepository;
        public readonly IUnitOfWork _unitOfWork;

        public CandidateService(ICandidateRepository candidateRepository, IUnitOfWork unitOfWork)
        {
            _candidateRepository = candidateRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<Candidate>> ListAsync()
        {
            return await _candidateRepository.ListAsync();
        }

        public async Task<IEnumerable<Candidate>> ListByPostIdAsync(int postId)
        {
            return await _candidateRepository.ListByPostIdAsync(postId);
        }

        public async Task<IEnumerable<Candidate>> ListByCandidateIdAsync(int candidateId)
        {
           return await _candidateRepository.ListByCandidateIdAsync(candidateId);
        }

        public async Task<CandidateResponse> AssignCandidateAsync(int postId, int candidateId)
        {
            try
            {

                await _candidateRepository.AssignCandidate(postId, candidateId);
                await _unitOfWork.CompleteAsync();
                Candidate productTag = await _candidateRepository.FindByPostIdAndCandidateId(postId, candidateId);
                return new CandidateResponse(productTag);
            }
            catch (Exception ex)
            {
                return new CandidateResponse($"An error ocurred while assigning Candidate to Post: {ex.Message}");
            }
        }

        public async Task<CandidateResponse> UnassignCandidateAsync(int postId, int candidateId)
        {
            try
            {
                Candidate candidate = await _candidateRepository.FindByPostIdAndCandidateId(postId, candidateId);
                _candidateRepository.Remove(candidate);
                await _unitOfWork.CompleteAsync();
                return new CandidateResponse(candidate);
            }
            catch (Exception ex)
            {
                return new CandidateResponse($"An error ocurred while unassigning Candidate to Post: {ex.Message}");
            }
        }
    }
}
