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
    public class MemberRepository : IMemberRepository
    {
        private readonly ApiClient _apiClient;
        private const string BaseUri = "api/members";

        public MemberRepository(ApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<List<MemberViewModel>> GetAllAsync()
        {
            return await _apiClient.GetAsync<List<MemberViewModel>>(BaseUri);
        }

        public async Task<MemberViewModel> GetByIdAsync(int id)
        {
            return await _apiClient.GetAsync<MemberViewModel>($"{BaseUri}/{id}");
        }

        public async Task<bool> CreateAsync(MemberViewModel member)
        {
            return await _apiClient.PostAsync(BaseUri, member);
        }

        public async Task<bool> UpdateAsync(int id, MemberViewModel member)
        {
            return await _apiClient.PutAsync($"{BaseUri}/{id}", member);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _apiClient.DeleteAsync($"{BaseUri}/{id}");
        }
    }
}
