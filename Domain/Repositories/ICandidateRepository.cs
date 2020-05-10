using Dopta.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dopta.API.Domain.Repositories
{
    public interface ICandidateRepository
    {
        Task<IEnumerable<Candidate>> ListAsync();
        Task<IEnumerable<Candidate>> ListByCandidateIdAsync(int candidateId);
        Task<IEnumerable<Candidate>> ListByPostIdAsync(int postId);
        Task<Candidate> FindByPostIdAndCandidateId(int postId, int candidateId);
        Task AddAsync(Candidate candidate);
        void Remove(Candidate candidate);
        Task AssignCandidate(int productId, int candidateId);
        void UnassignCandidate(int postId, int candidateId);
    }
}
