using GymManagerBlazor.BUS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagerBlazor.BUS.Services.Interface
{
    public interface IClassRegistrationService
    {
        Task<List<ClassRegistrationViewModel>> GetAllRegistrationsAsync();
        Task<ClassRegistrationViewModel> GetRegistrationByIdAsync(int id);
        Task<bool> CreateRegistrationAsync(ClassRegistrationViewModel registrationVM);
        Task<bool> UpdateRegistrationAsync(int id, ClassRegistrationViewModel registrationVM);
        Task<bool> DeleteRegistrationAsync(int id);
    }
}
