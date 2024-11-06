using GymManagerBlazor.BUS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagerBlazor.BUS.Services.Interface
{
    public interface IMemberService
    {
        Task<List<MemberViewModel>> GetAllMembersAsync();
        Task<MemberViewModel> GetMemberByIdAsync(int id);
        Task<bool> CreateMemberAsync(MemberViewModel memberVM);
        Task<bool> UpdateMemberAsync(int id, MemberViewModel memberVM);
        Task<bool> DeleteMemberAsync(int id);
    }
}
