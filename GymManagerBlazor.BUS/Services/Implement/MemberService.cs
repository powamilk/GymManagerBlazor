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
    public class MemberService : IMemberService
    {
        private readonly IMemberRepository _memberRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<MemberModel> _validator;

        public MemberService(IMemberRepository memberRepository, IMapper mapper, IValidator<MemberModel> validator)
        {
            _memberRepository = memberRepository;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<List<MemberModel>> GetAllMembersAsync()
        {
            var memberVMs = await _memberRepository.GetAllAsync();
            return _mapper.Map<List<MemberModel>>(memberVMs);
        }

        public async Task<MemberModel> GetMemberByIdAsync(int id)
        {
            var memberVM = await _memberRepository.GetByIdAsync(id);
            if (memberVM == null)
            {
                throw new Exception($"Không tìm thấy thành viên với ID = {id}");
            }
            return _mapper.Map<MemberModel>(memberVM);
        }

        public async Task<bool> CreateMemberAsync(MemberModel member)
        {
            var validationResult = await _validator.ValidateAsync(member);
            if (!validationResult.IsValid)
            {
                throw new FluentValidationException(validationResult.Errors);
            }

            var memberVM = _mapper.Map<MemberViewModel>(member);
            return await _memberRepository.CreateAsync(memberVM);
        }

        public async Task<bool> UpdateMemberAsync(int id, MemberModel member)
        {
            var validationResult = await _validator.ValidateAsync(member);
            if (!validationResult.IsValid)
            {
                throw new FluentValidationException(validationResult.Errors);
            }

            var memberVM = _mapper.Map<MemberViewModel>(member);
            return await _memberRepository.UpdateAsync(id, memberVM);
        }

        public async Task<bool> DeleteMemberAsync(int id)
        {
            return await _memberRepository.DeleteAsync(id);
        }
    }
}
