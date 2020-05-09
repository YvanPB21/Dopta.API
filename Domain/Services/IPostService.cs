using Dopta.API.Domain.Models;
using Dopta.API.Domain.Services.Communications;
using Dopta.API.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dopta.API.Domain.Services
{
    public interface IPostService
    {
        Task<IEnumerable<Post>> ListAsync();
        Task<PostResponse> SaveAsync(Post post);
        Task<PostResponse> UpdateAsync(int id, Post post);
        Task<PostResponse> DeleteAsync(int id);
        Task<IEnumerable<Post>> ListBySpecieIdAsync(int specieId);
        Task<IEnumerable<Post>> ListByCandidateIdAsync(int candidateId);
    }
}

