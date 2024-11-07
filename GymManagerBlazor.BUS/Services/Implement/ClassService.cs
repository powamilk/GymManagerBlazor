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
using AutoMapper;
using FluentValidation;
using GymManagerBlazor.BUS.Models;
using FluentValidationException = FluentValidation.ValidationException;

namespace GymManagerBlazor.BUS.Services.Implement
{
    public class ClassService : IClassService
    {
        private readonly IClassRepository _classRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<ClassModel> _validator;

        public ClassService(IClassRepository classRepository, IMapper mapper, IValidator<ClassModel> validator)
        {
            _classRepository = classRepository;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<List<ClassModel>> GetAllClassesAsync()
        {
            var classVMs = await _classRepository.GetAllAsync();
            return _mapper.Map<List<ClassModel>>(classVMs);
        }

        public async Task<ClassModel> GetClassByIdAsync(int id)
        {
            var classVM = await _classRepository.GetByIdAsync(id);
            if (classVM == null)
            {
                throw new Exception($"Không tìm thấy lớp học với ID = {id}");
            }
            return _mapper.Map<ClassModel>(classVM);
        }

        public async Task<bool> CreateClassAsync(ClassModel classModel)
        {
            var validationResult = await _validator.ValidateAsync(classModel);
            if (!validationResult.IsValid)
            {
                throw new FluentValidationException(validationResult.Errors);
            }

            var classVM = _mapper.Map<ClassViewModel>(classModel);
            return await _classRepository.CreateAsync(classVM);
        }

        public async Task<bool> UpdateClassAsync(int id, ClassModel classModel)
        {
            var validationResult = await _validator.ValidateAsync(classModel);
            if (!validationResult.IsValid)
            {
                throw new FluentValidationException(validationResult.Errors);
            }

            var classVM = _mapper.Map<ClassViewModel>(classModel);
            return await _classRepository.UpdateAsync(id, classVM);
        }

        public async Task<bool> DeleteClassAsync(int id)
        {
            return await _classRepository.DeleteAsync(id);
        }
    }
}
