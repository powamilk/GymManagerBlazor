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
    public class ClassRepository : IClassRepository
    {
        private readonly ApiClient _apiClient;
        private const string BaseUrl = "api/classes";

        public ClassRepository(ApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<List<ClassViewModel>> GetAllAsync()
        {
            return await _apiClient.GetAsync<List<ClassViewModel>>(BaseUrl);
        }

        public async Task<ClassViewModel> GetByIdAsync(int id)
        {
            return await _apiClient.GetAsync<ClassViewModel>($"{BaseUrl}/{id}");
        }

        public async Task<bool> CreateAsync(ClassViewModel classVM)
        {
            return await _apiClient.PostAsync(BaseUrl, classVM);
        }

        public async Task<bool> UpdateAsync(int id, ClassViewModel classVM)
        {
            return await _apiClient.PutAsync($"{BaseUrl}/{id}", classVM);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _apiClient.DeleteAsync($"{BaseUrl}/{id}");
        }
    }
}
