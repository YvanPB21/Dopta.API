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
    public class PostRepository : BaseRepository, IPostRepository
    {
        public PostRepository(AppDbContext context) : base(context) { }
        public async Task AddAsync(Post post)
        {
            await _context.Posts.AddAsync(post);
        }

        public async Task<IEnumerable<Post>> ListAsync()
        {
            return await _context.Posts.Include(p=> p.Pet).Include(p=> p.Candidates).ToListAsync();
        }

        public async Task<Post> FindById(int id)
        {
            return await _context.Posts.FindAsync(id);
        }

        public void Update(Post post)
        {
            _context.Posts.Update(post);
        }

        public void Remove(Post post)
        {
            _context.Posts.Remove(post);
        }
    }
}
