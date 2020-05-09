using Dopta.API.Domain.Models;
using Dopta.API.Domain.Services.Communications;
using Dopta.API.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dopta.API.Domain.Services
{
    public interface IPetService
    {
        Task<IEnumerable<Pet>> ListAsync();
        Task<PetResponse> SaveAsync(Pet pet);
        Task<PetResponse> UpdateAsync(int id, Pet pet);
        Task<PetResponse> DeleteAsync(int id);
      
    }
}
