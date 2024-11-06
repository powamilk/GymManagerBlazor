using GymManagerBlazor.BUS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagerBlazor.BUS.Services.Interface
{
    public interface IClassService
    {
        Task<List<ClassViewModel>> GetAllClassesAsync();
        Task<ClassViewModel> GetClassByIdAsync(int id);
        Task<bool> CreateClassAsync(ClassViewModel classVM);
        Task<bool> UpdateClassAsync(int id, ClassViewModel classVM);
        Task<bool> DeleteClassAsync(int id);
    }
}
