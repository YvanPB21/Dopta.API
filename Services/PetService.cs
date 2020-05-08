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
    public class PetService : IPetService
    {
        private readonly IPetRepository _petRepository;
        public readonly IUnitOfWork _unitOfWork;

        public PetService(IPetRepository petRepository, IUnitOfWork unitOfWork)
        {
            _petRepository = petRepository;
            _unitOfWork = unitOfWork;

        }


        public async Task<IEnumerable<Pet>> ListAsync()
        {
            return await _petRepository.ListAsync();
        }

        public async Task<PetResponse> SaveAsync(Pet pet)
        {
            try
            {
                await _petRepository.AddAsync(pet);
                await _unitOfWork.CompleteAsync();

                return new PetResponse(pet);
            }
            catch (Exception ex)
            {
                return new PetResponse($"An error ocurrred while saving the pet: { ex.Message }");
            }
        }

        public async Task<PetResponse> UpdateAsync(int id, Pet pet)
        {
            var existingPet = await _petRepository.FindById(id);
            if (existingPet == null)
                return new PetResponse("Pet not found");
            existingPet.Name = pet.Name;
            existingPet.SpecieId = pet.SpecieId; // POSIBLE ERROR

            try
            {
                _petRepository.Update(existingPet);
                await _unitOfWork.CompleteAsync();
                return new PetResponse(existingPet);
            }
            catch (Exception ex)
            {
                return new PetResponse($"An error ocurred while updating pet:{ex.Message}");
            }

        }

        public async Task<PetResponse> DeleteAsync(int id)
        {
            var deletePet = await _petRepository.FindById(id);
            if (deletePet == null)
                return new PetResponse("Pet not found");
            try
            {
                _petRepository.Remove(deletePet);
                await _unitOfWork.CompleteAsync();
                return new PetResponse(deletePet);
            }
            catch(Exception ex)
            {
                return new PetResponse($"An error ocurred while deleting pet:{ex.Message}");
            }
        }
    }
}
