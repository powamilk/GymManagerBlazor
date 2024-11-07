using AutoMapper;
using FluentValidation;
using GymManagerBlazor.BUS.Exceptions;
using GymManagerBlazor.BUS.Models;
using GymManagerBlazor.BUS.Services.Interface;
using GymManagerBlazor.BUS.Validators;
using GymManagerBlazor.BUS.ViewModels;
using GymManagerBlazor.DAL.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidationException = FluentValidation.ValidationException;

namespace GymManagerBlazor.BUS.Services.Implement
{
    public class TrainerService : ITrainerService
    {
        private readonly ITrainerRepository _trainerRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<TrainerModel> _validator;

        public TrainerService(ITrainerRepository trainerRepository, IMapper mapper, IValidator<TrainerModel> validator)
        {
            _trainerRepository = trainerRepository;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<List<TrainerModel>> GetAllTrainersAsync()
        {
            var trainerVMs = await _trainerRepository.GetAllAsync();
            return _mapper.Map<List<TrainerModel>>(trainerVMs);
        }

        public async Task<TrainerModel> GetTrainerByIdAsync(int id)
        {
            var trainerVM = await _trainerRepository.GetByIdAsync(id);
            if (trainerVM == null)
            {
                throw new Exception($"Không tìm thấy huấn luyện viên với ID = {id}");
            }
            return _mapper.Map<TrainerModel>(trainerVM);
        }

        public async Task<bool> CreateTrainerAsync(TrainerModel trainer)
        {
            var validationResult = await _validator.ValidateAsync(trainer);
            if (!validationResult.IsValid)
            {
                throw new FluentValidationException(validationResult.Errors);
            }

            var trainerVM = _mapper.Map<TrainerViewModel>(trainer);
            return await _trainerRepository.CreateAsync(trainerVM);
        }

        public async Task<bool> UpdateTrainerAsync(int id, TrainerModel trainer)
        {
            var validationResult = await _validator.ValidateAsync(trainer);
            if (!validationResult.IsValid)
            {
                throw new FluentValidationException(validationResult.Errors);
            }

            var trainerVM = _mapper.Map<TrainerViewModel>(trainer);
            return await _trainerRepository.UpdateAsync(id, trainerVM);
        }

        public async Task<bool> DeleteTrainerAsync(int id)
        {
            return await _trainerRepository.DeleteAsync(id);
        }
    }
}
