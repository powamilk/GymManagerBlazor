using GymManagerBlazor.BUS.Models;
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
        Task<List<TrainerModel>> GetAllTrainersAsync();
        Task<TrainerModel> GetTrainerByIdAsync(int id);
        Task<bool> CreateTrainerAsync(TrainerModel trainer);
        Task<bool> UpdateTrainerAsync(int id, TrainerModel trainer);
        Task<bool> DeleteTrainerAsync(int id);
    }
}
