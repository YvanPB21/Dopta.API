using Dopta.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dopta.API.Domain.Services
{
    public interface ICandidateService
    {
        Task<IEnumerable<Candidate>> ListAsync();
    }
}
