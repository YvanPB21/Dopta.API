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

        public async Task AssignCandidate(int postId, int candidateId)
        {
            Candidate candidate = await FindByPostIdAndCandidateId(postId, candidateId);
            if (candidate == null)
            {
                candidate = new Candidate { PostId = postId, AdopterId = candidateId };
                await AddAsync(candidate);
            }
        }

        public async Task<Candidate> FindByPostIdAndCandidateId(int postId, int candidateId)
        {
            return await _context.Candidates.FindAsync(postId, candidateId);
        }

        public async Task<IEnumerable<Candidate>> ListAsync()
        {
            return await _context.Candidates.Include(pt => pt.Post)
                .Include(pt => pt.Adopter).ToListAsync();
           
        }

        public async Task<IEnumerable<Candidate>> ListByCandidateIdAsync(int candidateId)
        {
            return await _context.Candidates
                .Where(pt => pt.AdopterId == candidateId)
                .Include(pt => pt.Post)
                .Include(pt => pt.Adopter)
                .ToListAsync();
        }

        public async Task<IEnumerable<Candidate>> ListByPostIdAsync(int postId)
        {
            return await _context.Candidates
            .Where(pt => pt.PostId == postId)
            .Include(pt => pt.Post)
            .Include(pt => pt.Adopter)
            .ToListAsync();
        }

        public void Remove(Candidate candidate)
        {
            _context.Candidates.Remove(candidate);
        }

        public async void UnassignCandidate(int postId, int candidateId)
        {
            Candidate candidate = await FindByPostIdAndCandidateId(postId, candidateId);
            if (candidate != null)
            {
                Remove(candidate);
            }
        }
    }

      
}
