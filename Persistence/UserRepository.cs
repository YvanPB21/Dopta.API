using Microsoft.EntityFrameworkCore;
using Dopta.API.Domain.Models;
using Dopta.API.Domain.Persistence.Contexts;
using Dopta.API.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace Dopta.API.Persistence
{
    public class UserRepository : BaseRepository , IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context) { }
        public async Task AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
        }

        public async Task<User> FindById(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<IEnumerable<User>> ListAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public void Remove(User user)
        {
            _context.Users.Remove(user);
        }

        public void Update(User user)
        {
            _context.Users.Update(user);
        }
    }
}
