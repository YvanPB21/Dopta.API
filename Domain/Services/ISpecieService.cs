using Dopta.API.Domain.Models;
using Dopta.API.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dopta.API.Domain.Services
{
    public interface ISpecieService
    {
        Task<IEnumerable<Specie>> ListAsync();
        Task<SpecieResponse> GetByIdAsync(int id);
        Task<SpecieResponse> SaveAsync(Specie specie);
        Task<SpecieResponse> UpdateAsync(int id, Specie specie);
        Task<SpecieResponse> DeleteAsync(int id);
    }
}
