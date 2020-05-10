using Dopta.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dopta.API.Domain.Repositories
{
    public interface IUserProfileRepository
    {
        Task<IEnumerable<UserProfile>> ListAsync();
        Task AddAsync(UserProfile userProfile);
        Task<UserProfile> FindById(int id);
        void Update(UserProfile userProfile);
        void Remove(UserProfile userProfile);
    }
}
