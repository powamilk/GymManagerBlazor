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
        Task<bool> CreateAsync(ClassRegistrationViewModel registrationVM);
        Task<bool> UpdateAsync(int id, ClassRegistrationViewModel registrationVM);
        Task<bool> DeleteAsync(int id);
    }
}
