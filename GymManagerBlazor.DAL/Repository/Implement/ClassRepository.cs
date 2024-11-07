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
        private const string BaseUri = "api/classes";

        public ClassRepository(ApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<List<ClassViewModel>> GetAllAsync()
        {
            return await _apiClient.GetAsync<List<ClassViewModel>>(BaseUri);
        }

        public async Task<ClassViewModel> GetByIdAsync(int id)
        {
            return await _apiClient.GetAsync<ClassViewModel>($"{BaseUri}/{id}");
        }

        public async Task<bool> CreateAsync(ClassViewModel classModel)
        {
            return await _apiClient.PostAsync(BaseUri, classModel);
        }

        public async Task<bool> UpdateAsync(int id, ClassViewModel classModel)
        {
            return await _apiClient.PutAsync($"{BaseUri}/{id}", classModel);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _apiClient.DeleteAsync($"{BaseUri}/{id}");
        }
    }
}
