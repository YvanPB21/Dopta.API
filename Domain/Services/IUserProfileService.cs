using Dopta.API.Domain.Models;
using Dopta.API.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dopta.API.Domain.Services
{
    public interface IUserProfileService
    {
        Task<IEnumerable<UserProfile>> ListAsync();
        Task<UserProfileResponse> GetByIdAsync(int id);
        Task<UserProfileResponse> SaveAsync(UserProfile userProfile);
        Task<UserProfileResponse> UpdateAsync(int id, UserProfile userProfile);
        Task<UserProfileResponse> DeleteAsync(int id);
    }
}
