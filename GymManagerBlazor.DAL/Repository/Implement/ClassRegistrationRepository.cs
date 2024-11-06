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
    public class ClassRegistrationRepository : IClassRegistrationRepository
    {
        private readonly ApiClient _apiClient;
        private const string BaseUrl = "api/registrations";

        public ClassRegistrationRepository(ApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<List<ClassRegistrationViewModel>> GetAllAsync()
        {
            return await _apiClient.GetAsync<List<ClassRegistrationViewModel>>(BaseUrl);
        }

        public async Task<ClassRegistrationViewModel> GetByIdAsync(int id)
        {
            return await _apiClient.GetAsync<ClassRegistrationViewModel>($"{BaseUrl}/{id}");
        }

        public async Task<bool> CreateAsync(ClassRegistrationViewModel registrationVM)
        {
            return await _apiClient.PostAsync(BaseUrl, registrationVM);
        }

        public async Task<bool> UpdateAsync(int id, ClassRegistrationViewModel registrationVM)
        {
            return await _apiClient.PutAsync($"{BaseUrl}/{id}", registrationVM);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _apiClient.DeleteAsync($"{BaseUrl}/{id}");
        }
    }
}
