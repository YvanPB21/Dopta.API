using Dopta.API.Domain.Models;
using Dopta.API.Domain.Persistence.Contexts;
using Dopta.API.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dopta.API.Persistence
{
    public class CandidateRepository : BaseRepository, ICandidateRepository
    {
        public CandidateRepository(AppDbContext context) : base(context) { }
        public async Task AddAsync(Candidate candidate)
        {
            await _context.Candidates.AddAsync(candidate);
        }

        public async Task<IEnumerable<Candidate>> ListAsync()
        {
            return await _context.Candidates.Include(p => p.Post).Include(p => p.Adopter).ToListAsync();
        }
    }
}
