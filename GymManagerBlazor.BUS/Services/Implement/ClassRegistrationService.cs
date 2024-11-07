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
    public class ClassRegistrationService : IClassRegistrationService
    {
        private readonly IClassRegistrationRepository _registrationRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<ClassRegistrationModel> _validator;

        public ClassRegistrationService(IClassRegistrationRepository registrationRepository, IMapper mapper, IValidator<ClassRegistrationModel> validator)
        {
            _registrationRepository = registrationRepository;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<List<ClassRegistrationModel>> GetAllRegistrationsAsync()
        {
            var registrationVMs = await _registrationRepository.GetAllAsync();
            return _mapper.Map<List<ClassRegistrationModel>>(registrationVMs);
        }

        public async Task<ClassRegistrationModel> GetRegistrationByIdAsync(int id)
        {
            var registrationVM = await _registrationRepository.GetByIdAsync(id);
            if (registrationVM == null)
            {
                throw new Exception($"Không tìm thấy đăng ký với ID = {id}");
            }
            return _mapper.Map<ClassRegistrationModel>(registrationVM);
        }

        public async Task<bool> CreateRegistrationAsync(ClassRegistrationModel registration)
        {
            var validationResult = await _validator.ValidateAsync(registration);
            if (!validationResult.IsValid)
            {
                throw new FluentValidationException(validationResult.Errors);
            }

            var registrationVM = _mapper.Map<ClassRegistrationViewModel>(registration);
            return await _registrationRepository.CreateAsync(registrationVM);
        }

        public async Task<bool> UpdateRegistrationAsync(int id, ClassRegistrationModel registration)
        {
            var validationResult = await _validator.ValidateAsync(registration);
            if (!validationResult.IsValid)
            {
                throw new FluentValidationException(validationResult.Errors);
            }

            var registrationVM = _mapper.Map<ClassRegistrationViewModel>(registration);
            return await _registrationRepository.UpdateAsync(id, registrationVM);
        }

        public async Task<bool> DeleteRegistrationAsync(int id)
        {
            return await _registrationRepository.DeleteAsync(id);
        }
    }
}
