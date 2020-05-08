using Dopta.API.Domain.Models;
using Dopta.API.Domain.Repositories;
using Dopta.API.Domain.Services;
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
    }
}
