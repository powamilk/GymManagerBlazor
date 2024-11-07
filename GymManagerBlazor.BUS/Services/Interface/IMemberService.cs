using GymManagerBlazor.BUS.Models;
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
        Task<List<MemberModel>> GetAllMembersAsync();
        Task<MemberModel> GetMemberByIdAsync(int id);
        Task<bool> CreateMemberAsync(MemberModel member);
        Task<bool> UpdateMemberAsync(int id, MemberModel member);
        Task<bool> DeleteMemberAsync(int id);
    }
}
