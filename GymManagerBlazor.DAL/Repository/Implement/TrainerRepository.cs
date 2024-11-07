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
        private const string BaseUri = "api/trainers";

        public TrainerRepository(ApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<List<TrainerViewModel>> GetAllAsync()
        {
            return await _apiClient.GetAsync<List<TrainerViewModel>>(BaseUri);
        }

        public async Task<TrainerViewModel> GetByIdAsync(int id)
        {
            return await _apiClient.GetAsync<TrainerViewModel>($"{BaseUri}/{id}");
        }

        public async Task<bool> CreateAsync(TrainerViewModel trainer)
        {
            return await _apiClient.PostAsync(BaseUri, trainer);
        }

        public async Task<bool> UpdateAsync(int id, TrainerViewModel trainer)
        {
            return await _apiClient.PutAsync($"{BaseUri}/{id}", trainer);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _apiClient.DeleteAsync($"{BaseUri}/{id}");
        }
    }
}
