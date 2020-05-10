using Microsoft.EntityFrameworkCore;
using Dopta.API.Domain.Models;
using Dopta.API.Domain.Persistence.Contexts;
using Dopta.API.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dopta.API.Persistence
{
    public class PetRepository : BaseRepository, IPetRepository
    {
        public PetRepository(AppDbContext context) : base(context) {}

        public async Task AddAsync(Pet pet)
        {
            await _context.Pets.AddAsync(pet);
        }

        public async Task<IEnumerable<Pet>> ListAsync()
        {
           return await _context.Pets.Include(p => p.Specie).ToListAsync();
        }
        public async Task<Pet> FindById(int id)
        {
            return await _context.Pets.FindAsync(id);
        }
        public void Update(Pet pet)
        {
            _context.Pets.Update(pet);
        }

        public void Remove(Pet pet)
        {
            _context.Pets.Remove(pet);
        }

        
    }
}
