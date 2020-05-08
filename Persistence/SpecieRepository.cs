using Microsoft.EntityFrameworkCore; //<- ORM OBJECT RELATIONAL MODEL 
using Dopta.API.Domain.Models;
using Dopta.API.Domain.Persistence.Contexts;
using Dopta.API.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dopta.API.Persistence
{
    public class SpecieRepository : BaseRepository, ISpecieRepository
    {
       public SpecieRepository(AppDbContext context): base(context){ }
        public async Task AddAsync(Specie specie)
        {
            await _context.Species.AddAsync(specie);
        }

        public async Task<IEnumerable<Specie>> ListAsync()
        {
            return await _context.Species.ToListAsync();
        }

        public async Task<Specie> FindById(int id)
        {
            return await _context.Species.FindAsync(id);
        }

        public void Update(Specie specie)
        {
            _context.Species.Update(specie);
        }

        public void Remove(Specie specie)
        {
            _context.Species.Remove(specie);
        }
    }
}
