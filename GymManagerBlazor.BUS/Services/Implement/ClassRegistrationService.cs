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
    public class ClassRegistrationService : IClassRegistrationService
    {
        private readonly IClassRegistrationRepository _registrationRepository;
        private readonly ClassRegistrationValidator _registrationValidator;

        public ClassRegistrationService(IClassRegistrationRepository registrationRepository)
        {
            _registrationRepository = registrationRepository;
            _registrationValidator = new ClassRegistrationValidator();
        }

        public async Task<List<ClassRegistrationViewModel>> GetAllRegistrationsAsync()
        {
            return await _registrationRepository.GetAllAsync();
        }

        public async Task<ClassRegistrationViewModel> GetRegistrationByIdAsync(int id)
        {
            var registrationEntity = await _registrationRepository.GetByIdAsync(id);
            if (registrationEntity == null)
            {
                throw new EntityNotFoundException("Class Registration", id);
            }
            return registrationEntity;
        }

        public async Task<bool> CreateRegistrationAsync(ClassRegistrationViewModel registrationVM)
        {
            var validationResult = _registrationValidator.Validate(registrationVM);
            if (!validationResult.IsValid)
            {
                var errors = new Dictionary<string, string>();
                foreach (var failure in validationResult.Errors)
                {
                    errors[failure.PropertyName] = failure.ErrorMessage;
                }
                throw new ValidationException(errors);
            }

            return await _registrationRepository.CreateAsync(registrationVM);
        }

        public async Task<bool> UpdateRegistrationAsync(int id, ClassRegistrationViewModel registrationVM)
        {
            var validationResult = _registrationValidator.Validate(registrationVM);
            if (!validationResult.IsValid)
            {
                var errors = new Dictionary<string, string>();
                foreach (var failure in validationResult.Errors)
                {
                    errors[failure.PropertyName] = failure.ErrorMessage;
                }
                throw new ValidationException(errors);
            }

            if (await _registrationRepository.GetByIdAsync(id) == null)
            {
                throw new EntityNotFoundException("Class Registration", id);
            }

            return await _registrationRepository.UpdateAsync(id, registrationVM);
        }

        public async Task<bool> DeleteRegistrationAsync(int id)
        {
            if (await _registrationRepository.GetByIdAsync(id) == null)
            {
                throw new EntityNotFoundException("Class Registration", id);
            }

            return await _registrationRepository.DeleteAsync(id);
        }
    }
}
