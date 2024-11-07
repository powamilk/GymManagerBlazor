using GymManagerBlazor.BUS.Models;
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
        Task<List<ClassRegistrationModel>> GetAllRegistrationsAsync();
        Task<ClassRegistrationModel> GetRegistrationByIdAsync(int id);
        Task<bool> CreateRegistrationAsync(ClassRegistrationModel registration);
        Task<bool> UpdateRegistrationAsync(int id, ClassRegistrationModel registration);
        Task<bool> DeleteRegistrationAsync(int id);
    }
}
