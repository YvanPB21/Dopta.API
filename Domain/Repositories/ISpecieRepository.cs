using Dopta.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dopta.API.Domain.Repositories
{
   public interface ISpecieRepository
    {
        Task<IEnumerable<Specie>> ListAsync();
        Task AddAsync(Specie specie);
        Task<Specie> FindById(int id);
        void Update(Specie specie);
        void Remove(Specie specie);
    }
}
