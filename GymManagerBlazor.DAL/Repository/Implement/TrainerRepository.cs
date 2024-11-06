using GymManagerBlazor.BUS.ViewModels;
using GymManagerBlazor.DAL.DataAccess;
using GymManagerBlazor.DAL.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagerBlazor.DAL.Repository.Implement
{
    public class TrainerRepository : ITrainerRepository
    {
        private readonly ApiClient _apiClient;
        private const string BaseUrl = "api/trainers";

        public TrainerRepository(ApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<List<TrainerViewModel>> GetAllAsync()
        {
            return await _apiClient.GetAsync<List<TrainerViewModel>>(BaseUrl);
        }

        public async Task<TrainerViewModel> GetByIdAsync(int id)
        {
            return await _apiClient.GetAsync<TrainerViewModel>($"{BaseUrl}/{id}");
        }

        public async Task<bool> CreateAsync(TrainerViewModel trainerVM)
        {
            return await _apiClient.PostAsync(BaseUrl, trainerVM);
        }

        public async Task<bool> UpdateAsync(int id, TrainerViewModel trainerVM)
        {
            return await _apiClient.PutAsync($"{BaseUrl}/{id}", trainerVM);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _apiClient.DeleteAsync($"{BaseUrl}/{id}");
        }
    }
}
