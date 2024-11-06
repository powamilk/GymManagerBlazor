using GymManagerBlazor.BUS.Exceptions;
using GymManagerBlazor.BUS.Services.Interface;
using GymManagerBlazor.BUS.Validators;
using GymManagerBlazor.BUS.ViewModels;
using GymManagerBlazor.DAL.Repository.Interfaces;
using GymManagerBlazor.BUS.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagerBlazor.BUS.Services.Implement
{
    public class ClassService : IClassService
    {
        private readonly IClassRepository _classRepository;
        private readonly ClassValidator _classValidator;

        public ClassService(IClassRepository classRepository)
        {
            _classRepository = classRepository;
            _classValidator = new ClassValidator();
        }

        public async Task<List<ClassViewModel>> GetAllClassesAsync()
        {
            return await _classRepository.GetAllAsync();
        }

        public async Task<ClassViewModel> GetClassByIdAsync(int id)
        {
            var classEntity = await _classRepository.GetByIdAsync(id);
            if (classEntity == null)
            {
                throw new EntityNotFoundException("Class", id);
            }
            return classEntity;
        }

        public async Task<bool> CreateClassAsync(ClassViewModel classVM)
        {
            var validationResult = _classValidator.Validate(classVM);
            if (!validationResult.IsValid)
            {
                var errors = new Dictionary<string, string>();
                foreach (var failure in validationResult.Errors)
                {
                    errors[failure.PropertyName] = failure.ErrorMessage;
                }
                throw new ValidationException(errors);
            }

            return await _classRepository.CreateAsync(classVM);
        }

        public async Task<bool> UpdateClassAsync(int id, ClassViewModel classVM)
        {
            var validationResult = _classValidator.Validate(classVM);
            if (!validationResult.IsValid)
            {
                var errors = new Dictionary<string, string>();
                foreach (var failure in validationResult.Errors)
                {
                    errors[failure.PropertyName] = failure.ErrorMessage;
                }
                throw new ValidationException(errors);
            }

            if (await _classRepository.GetByIdAsync(id) == null)
            {
                throw new EntityNotFoundException("Class", id);
            }

            return await _classRepository.UpdateAsync(id, classVM);
        }

        public async Task<bool> DeleteClassAsync(int id)
        {
            if (await _classRepository.GetByIdAsync(id) == null)
            {
                throw new EntityNotFoundException("Class", id);
            }

            return await _classRepository.DeleteAsync(id);
        }
    }
}
