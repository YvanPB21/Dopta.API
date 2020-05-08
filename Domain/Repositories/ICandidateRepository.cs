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
    }
}
