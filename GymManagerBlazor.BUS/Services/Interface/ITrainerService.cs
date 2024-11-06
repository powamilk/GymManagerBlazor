using GymManagerBlazor.BUS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagerBlazor.BUS.Services.Interface
{
    public interface ITrainerService
    {
        Task<List<TrainerViewModel>> GetAllTrainersAsync();
        Task<TrainerViewModel> GetTrainerByIdAsync(int id);
        Task<bool> CreateTrainerAsync(TrainerViewModel trainerVM);
        Task<bool> UpdateTrainerAsync(int id, TrainerViewModel trainerVM);
        Task<bool> DeleteTrainerAsync(int id);
    }
}
