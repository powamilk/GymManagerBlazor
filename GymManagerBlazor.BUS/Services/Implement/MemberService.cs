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
    public class MemberService : IMemberService
    {
        private readonly IMemberRepository _memberRepository;
        private readonly MemberValidator _memberValidator;

        public MemberService(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
            _memberValidator = new MemberValidator();
        }

        public async Task<List<MemberViewModel>> GetAllMembersAsync()
        {
            return await _memberRepository.GetAllAsync();
        }

        public async Task<MemberViewModel> GetMemberByIdAsync(int id)
        {
            var memberEntity = await _memberRepository.GetByIdAsync(id);
            if (memberEntity == null)
            {
                throw new EntityNotFoundException("Member", id);
            }
            return memberEntity;
        }

        public async Task<bool> CreateMemberAsync(MemberViewModel memberVM)
        {
            var validationResult = _memberValidator.Validate(memberVM);
            if (!validationResult.IsValid)
            {
                var errors = new Dictionary<string, string>();
                foreach (var failure in validationResult.Errors)
                {
                    errors[failure.PropertyName] = failure.ErrorMessage;
                }
                throw new ValidationException(errors);
            }

            return await _memberRepository.CreateAsync(memberVM);
        }

        public async Task<bool> UpdateMemberAsync(int id, MemberViewModel memberVM)
        {
            var validationResult = _memberValidator.Validate(memberVM);
            if (!validationResult.IsValid)
            {
                var errors = new Dictionary<string, string>();
                foreach (var failure in validationResult.Errors)
                {
                    errors[failure.PropertyName] = failure.ErrorMessage;
                }
                throw new ValidationException(errors);
            }

            if (await _memberRepository.GetByIdAsync(id) == null)
            {
                throw new EntityNotFoundException("Member", id);
            }

            return await _memberRepository.UpdateAsync(id, memberVM);
        }

        public async Task<bool> DeleteMemberAsync(int id)
        {
            if (await _memberRepository.GetByIdAsync(id) == null)
            {
                throw new EntityNotFoundException("Member", id);
            }

            return await _memberRepository.DeleteAsync(id);
        }
    }
}
