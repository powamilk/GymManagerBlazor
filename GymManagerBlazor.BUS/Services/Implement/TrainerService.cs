using GymManagerBlazor.BUS.Exceptions;
using GymManagerBlazor.BUS.Services.Interface;
using GymManagerBlazor.BUS.Validators;
using GymManagerBlazor.BUS.ViewModels;
using GymManagerBlazor.DAL.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagerBlazor.BUS.Services.Implement
{
    public class TrainerService : ITrainerService
    {
        private readonly ITrainerRepository _trainerRepository;
        private readonly TrainerValidator _trainerValidator;

        public TrainerService(ITrainerRepository trainerRepository)
        {
            _trainerRepository = trainerRepository;
            _trainerValidator = new TrainerValidator();
        }

        public async Task<List<TrainerViewModel>> GetAllTrainersAsync()
        {
            return await _trainerRepository.GetAllAsync();
        }

        public async Task<TrainerViewModel> GetTrainerByIdAsync(int id)
        {
            var trainerEntity = await _trainerRepository.GetByIdAsync(id);
            if (trainerEntity == null)
            {
                throw new EntityNotFoundException("Trainer", id);
            }
            return trainerEntity;
        }

        public async Task<bool> CreateTrainerAsync(TrainerViewModel trainerVM)
        {
            var validationResult = _trainerValidator.Validate(trainerVM);
            if (!validationResult.IsValid)
            {
                var errors = new Dictionary<string, string>();
                foreach (var failure in validationResult.Errors)
                {
                    errors[failure.PropertyName] = failure.ErrorMessage;
                }
                throw new ValidationException(errors);
            }

            return await _trainerRepository.CreateAsync(trainerVM);
        }

        public async Task<bool> UpdateTrainerAsync(int id, TrainerViewModel trainerVM)
        {
            var validationResult = _trainerValidator.Validate(trainerVM);
            if (!validationResult.IsValid)
            {
                var errors = new Dictionary<string, string>();
                foreach (var failure in validationResult.Errors)
                {
                    errors[failure.PropertyName] = failure.ErrorMessage;
                }
                throw new ValidationException(errors);
            }

            if (await _trainerRepository.GetByIdAsync(id) == null)
            {
                throw new EntityNotFoundException("Trainer", id);
            }

            return await _trainerRepository.UpdateAsync(id, trainerVM);
        }

        public async Task<bool> DeleteTrainerAsync(int id)
        {
            if (await _trainerRepository.GetByIdAsync(id) == null)
            {
                throw new EntityNotFoundException("Trainer", id);
            }

            return await _trainerRepository.DeleteAsync(id);
        }
    }
}
