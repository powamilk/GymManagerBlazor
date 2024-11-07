using GymManagerBlazor.BUS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagerBlazor.DAL.Repository.Interfaces
{
    public interface IClassRegistrationRepository
    {
        Task<List<ClassRegistrationViewModel>> GetAllAsync();
        Task<ClassRegistrationViewModel> GetByIdAsync(int id);
        Task<bool> CreateAsync(ClassRegistrationViewModel registration);
        Task<bool> UpdateAsync(int id, ClassRegistrationViewModel registration);
        Task<bool> DeleteAsync(int id);
    }
}
