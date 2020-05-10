using Dopta.API.Domain.Models;
using Dopta.API.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dopta.API.Domain.Services
{
    public interface ICandidateService
    {
        Task<IEnumerable<Candidate>> ListAsync();
        Task<IEnumerable<Candidate>> ListByPostIdAsync(int postId);
        Task<IEnumerable<Candidate>> ListByCandidateIdAsync(int canididateId);
        Task<CandidateResponse> AssignCandidateAsync(int postId, int candidateId);
        Task<CandidateResponse> UnassignCandidateAsync(int postId, int candidateId);
    }
}
