using GymManagerBlazor.BUS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagerBlazor.DAL.Repository.Interfaces
{
    public interface IMemberRepository
    {
        Task<List<MemberViewModel>> GetAllAsync();
        Task<MemberViewModel> GetByIdAsync(int id);
        Task<bool> CreateAsync(MemberViewModel memberVM);
        Task<bool> UpdateAsync(int id, MemberViewModel memberVM);
        Task<bool> DeleteAsync(int id);
    }
}
