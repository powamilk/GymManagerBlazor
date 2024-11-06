using GymManagerBlazor.BUS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagerBlazor.DAL.Repository.Interfaces
{
    public interface ITrainerRepository
    {
        Task<List<TrainerViewModel>> GetAllAsync();
        Task<TrainerViewModel> GetByIdAsync(int id);
        Task<bool> CreateAsync(TrainerViewModel trainerVM);
        Task<bool> UpdateAsync(int id, TrainerViewModel trainerVM);
        Task<bool> DeleteAsync(int id);
    }
}
