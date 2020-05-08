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
    public class SpecieService : ISpecieService
    {
        private readonly ISpecieRepository _specieRepository;
        public readonly IUnitOfWork _unitOfWork;

        public SpecieService(ISpecieRepository specieRepository,IUnitOfWork unitOfWork)
        {
            _specieRepository = specieRepository;
            _unitOfWork = unitOfWork;   
        }

        public async Task<IEnumerable<Specie>> ListAsync()
        {
            return await _specieRepository.ListAsync();
        }

        public async Task<SpecieResponse> SaveAsync(Specie specie)
        {
           try
            {
                await _specieRepository.AddAsync(specie);
                await _unitOfWork.CompleteAsync();

                return new SpecieResponse(specie);
            }
            catch(Exception ex)
            {
                return new SpecieResponse($"An error ocurrred while saving the specie: { ex.Message }");
            }
        }

        public async Task<SpecieResponse> UpdateAsync(int id, Specie specie)
        {
            var existingSpecie = await _specieRepository.FindById(id);
            if (existingSpecie == null)
                return new SpecieResponse("Specie not found");
            existingSpecie.Name = specie.Name;
            try
            {
                _specieRepository.Update(existingSpecie);
                await _unitOfWork.CompleteAsync();

                return new SpecieResponse(existingSpecie);
            }
            catch (Exception ex)
            {
                return new SpecieResponse($"An error ocurred while updating specie: {ex.Message}");
            }
        }

        public async Task<SpecieResponse> DeleteAsync(int id)
        {
            var existingSpecie = await _specieRepository.FindById(id);
            if (existingSpecie == null)
                return new SpecieResponse("Specie not found");
            try
            {
                _specieRepository.Remove(existingSpecie);
                await _unitOfWork.CompleteAsync();
                return new SpecieResponse(existingSpecie);
            }
            catch (Exception ex)
            {
                return new SpecieResponse($"An error ocurred while deleting specie: {ex.Message}");
            }
        }

        public async Task<SpecieResponse> GetByIdAsync(int id)
        {
            var existingSpecie = await _specieRepository.FindById(id);
            if (existingSpecie == null)
                return new SpecieResponse("Specie not found");
            return new SpecieResponse(existingSpecie);
        }
    }
}

