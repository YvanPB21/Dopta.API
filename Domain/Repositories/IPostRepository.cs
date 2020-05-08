using Dopta.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dopta.API.Domain.Repositories
{
    public interface IPostRepository
    {
        Task<IEnumerable<Post>> ListAsync();
        Task AddAsync(Post post);
        Task<Post> FindById(int id);
        void Update(Post post);
        void Remove(Post post);
    }
}
