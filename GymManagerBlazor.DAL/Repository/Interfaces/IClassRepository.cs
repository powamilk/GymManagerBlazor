using GymManagerBlazor.BUS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagerBlazor.DAL.Repository.Interfaces
{
    public interface IClassRepository
    {
        Task<List<ClassViewModel>> GetAllAsync();
        Task<ClassViewModel> GetByIdAsync(int id);
        Task<bool> CreateAsync(ClassViewModel classModel);
        Task<bool> UpdateAsync(int id, ClassViewModel classModel);
        Task<bool> DeleteAsync(int id);
    }
}
