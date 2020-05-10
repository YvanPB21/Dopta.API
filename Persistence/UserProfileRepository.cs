<<<<<<< HEAD
﻿using Dopta.API.Domain.Models;
using Dopta.API.Domain.Persistence.Contexts;
using Dopta.API.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dopta.API.Persistence
{
    public class UserProfileRepository : BaseRepository, IUserProfileRepository
    {
        public UserProfileRepository(AppDbContext context) : base(context) { }
        public async Task AddAsync(UserProfile user)
        {
            await _context.UserProfiles.AddAsync(user);
        }

        public async Task<UserProfile> FindById(int id)
        {
            return await _context.UserProfiles.FindAsync(id);
        }

        public async Task<IEnumerable<UserProfile>> ListAsync()
        {
            return await _context.UserProfiles.ToListAsync();
        }

        public void Remove(UserProfile user)
        {
            _context.UserProfiles.Remove(user);
        }

        public void Update(UserProfile user)
        {
            _context.UserProfiles.Update(user);
        }
    }
}
=======
﻿using Dopta.API.Domain.Models;
using Dopta.API.Domain.Persistence.Contexts;
using Dopta.API.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dopta.API.Persistence
{
    public class UserProfileRepository : BaseRepository, IUserProfileRepository
    {
        public UserProfileRepository(AppDbContext context) : base(context) { }
        public async Task AddAsync(UserProfile user)
        {
            await _context.UserProfiles.AddAsync(user);
        }

        public async Task<UserProfile> FindById(int id)
        {
            return await _context.UserProfiles.FindAsync(id);
        }

        public async Task<IEnumerable<UserProfile>> ListAsync()
        {
            return await _context.UserProfiles.ToListAsync();
        }

        public void Remove(UserProfile user)
        {
            _context.UserProfiles.Remove(user);
        }

        public void Update(UserProfile user)
        {
            _context.UserProfiles.Update(user);
        }
    }
}
>>>>>>> Miguel
