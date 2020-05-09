using Dopta.API.Domain.Models;
using Dopta.API.Domain.Repositories;
using Dopta.API.Domain.Services;
using Dopta.API.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dopta.API.Services
{
    public class UserProfileService : IUserProfileService
    {
        private readonly IUserProfileRepository _userRepository;
        public readonly IUnitOfWork _unitOfWork;

        public UserProfileService(IUserProfileRepository userRepository, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<UserProfile>> ListAsync()
        {
            return await _userRepository.ListAsync();
        }

        public async Task<UserProfileResponse> SaveAsync(UserProfile userProfile)
        {
            try
            {
                await _userRepository.AddAsync(userProfile);
                await _unitOfWork.CompleteAsync();

                return new UserProfileResponse(userProfile);
            }
            catch (Exception ex)
            {
                return new UserProfileResponse($"An error ocurrred while saving the specie: { ex.Message }");
            }
        }

        public async Task<UserProfileResponse> GetByIdAsync(int id)
        {
            var existingUserProfile = await _userRepository.FindById(id);
            if (existingUserProfile == null)
                return new UserProfileResponse("UserProfile not found");
            return new UserProfileResponse(existingUserProfile);
        }

        public async Task<UserProfileResponse> UpdateAsync(int id, UserProfile userProfile)
        {
            var existingUserProfile = await _userRepository.FindById(id);
            if (existingUserProfile == null)
                return new UserProfileResponse("UserProfile not found");
            //existingUserProfile.Name = userProfile.Name;
            try
            {
                _userRepository.Update(existingUserProfile);
                await _unitOfWork.CompleteAsync();

                return new UserProfileResponse(existingUserProfile);
            }
            catch (Exception ex)
            {
                return new UserProfileResponse($"An error ocurred while updating userProfile: {ex.Message}");
            }
        }

        public async Task<UserProfileResponse> DeleteAsync(int id)
        {
            var existingUserProfile = await _userRepository.FindById(id);
            if (existingUserProfile == null)
                return new UserProfileResponse("Specie not found");
            try
            {
                _userRepository.Remove(existingUserProfile);
                await _unitOfWork.CompleteAsync();
                return new UserProfileResponse(existingUserProfile);
            }
            catch (Exception ex)
            {
                return new UserProfileResponse($"An error ocurred while deleting the userProfile: {ex.Message}");
            }
        }
    }
}
