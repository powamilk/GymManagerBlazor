using GymManagerBlazor.BUS.Models;
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
        Task<List<ClassModel>> GetAllClassesAsync();
        Task<ClassModel> GetClassByIdAsync(int id);
        Task<bool> CreateClassAsync(ClassModel classModel);
        Task<bool> UpdateClassAsync(int id, ClassModel classModel);
        Task<bool> DeleteClassAsync(int id);
    }
}
