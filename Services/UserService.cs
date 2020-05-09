using Dopta.API.Domain.Models;
using Dopta.API.Domain.Repositories;
using Dopta.API.Domain.Services;
using Dopta.API.Domain.Services.Communications;
using Dopta.API.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dopta.API.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public readonly IUnitOfWork _unitOfWork;
        private readonly ICandidateRepository _candidateRepository;

        public UserService(IUserRepository userRepository,IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<User>> ListAsync()
        {
            return await _userRepository.ListAsync();
        }

        public async Task<UserResponse> SaveAsync(User user)
        {
            try
            {
                await _userRepository.AddAsync(user);
                await _unitOfWork.CompleteAsync();

                return new UserResponse(user);
            }
            catch (Exception ex)
            {
                return new UserResponse($"An error ocurrred while saving the specie: { ex.Message }");
            }
        }

        public async Task<UserResponse> GetByIdAsync(int id)
        {
            var existingUser = await _userRepository.FindById(id);
            if (existingUser == null)
                return new UserResponse("User not found");
            return new UserResponse(existingUser);
        }

        public async Task<UserResponse> UpdateAsync(int id, User user)
        {
            var existingUser = await _userRepository.FindById(id);
            if (existingUser == null)
                return new UserResponse("User not found");
            //existingUser.Name = user.Name;
            try
            {
                _userRepository.Update(existingUser);
                await _unitOfWork.CompleteAsync();

                return new UserResponse(existingUser);
            }
            catch (Exception ex)
            {
                return new UserResponse($"An error ocurred while updating user: {ex.Message}");
            }
        }

        public async Task<UserResponse> DeleteAsync(int id)
        {
            var existingUser = await _userRepository.FindById(id);
            if (existingUser == null)
                return new UserResponse("Specie not found");
            try
            {
                _userRepository.Remove(existingUser);
                await _unitOfWork.CompleteAsync();
                return new UserResponse(existingUser);
            }
            catch (Exception ex)
            {
                return new UserResponse($"An error ocurred while deleting the user: {ex.Message}");
            }
        }
        public async Task<IEnumerable<User>> ListByPostIdAsync(int postId)
        {
            var candidates = await _candidateRepository.ListByPostIdAsync(postId);
            var tags = candidates.Select(pt => pt.Adopter).ToList();
            return tags;

        }
    }
}
