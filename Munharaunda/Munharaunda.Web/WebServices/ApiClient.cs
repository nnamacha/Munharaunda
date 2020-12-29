using Munharaunda.Domain.Contracts;
using Munharaunda.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Munharaunda.Web.WebServices
{
    public class ApiClient : IApiClient
    {
        private readonly HttpClient _httpClient;
        private String typeName;


        public ApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        #region Private Methods

        private async Task<ResponseModel<T>> CallCreate<T>(T rec)
        {
            typeName = rec.GetType().Name;

            var response = await _httpClient.PostAsJsonAsync($"/api/{typeName}", rec);

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsAsync<ResponseModel<T>>();
        }

        #endregion

        public async Task<ResponseModel<Funeral>> CreateFuneral(Funeral funeral)
        {
            var response = await _httpClient.PostAsJsonAsync($"/api/Funeral", funeral);

            response.EnsureSuccessStatusCode();

            return await  response.Content.ReadAsAsync<ResponseModel<Funeral>>();
        }

        public async Task<ResponseModel<IdentityTypes>> CreateIdentityType(IdentityTypes identityType)
        {
            return await CallCreate<IdentityTypes>(identityType);
        }

       

        public async Task<ResponseModel<Profile>> CreateProfile(Profile profile)
        {
            var response = await _httpClient.PostAsJsonAsync($"/api/Profile", profile);

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsAsync<ResponseModel<Profile>>();
        }

        public async Task<ResponseModel<ProfileTypes>> CreateProfileType(ProfileTypes profileType)
        {
            var response = await _httpClient.PostAsJsonAsync($"/api/ProfileTypes", profileType);

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsAsync<ResponseModel<ProfileTypes>>();
        }

        public async Task<ResponseModel<Statuses>> CreateStatuses(Statuses status)
        {
            var response = await _httpClient.PostAsJsonAsync($"/api/Statuses", status);

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsAsync<ResponseModel<Statuses>>(); 
        }

        public async Task<ResponseModel<TransactionCodes>> CreateTransactionCode(TransactionCodes transactionCode)
        {
            var response = await _httpClient.PostAsJsonAsync($"/api/TransactionCodes", transactionCode);

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsAsync<ResponseModel<TransactionCodes>>();
        }

        public async Task<ResponseModel<Transactions>> CreateTransactions(Transactions transaction)
        {
            var response = await _httpClient.PostAsJsonAsync($"/api/Transactions", transaction);

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsAsync<ResponseModel<Transactions>>();
        }

        public async Task<ResponseModel<Funeral>> DeleteFuneralById(int id)
        {
            var response = await _httpClient.DeleteAsync($"/api/Funeral/{id}");

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsAsync<ResponseModel<Funeral>>();
        }

        public async Task<ResponseModel<IdentityTypes>> DeleteIdentityType(int id)
        {
            var response = await _httpClient.DeleteAsync($"/api/IdentityTypes/{id}");

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsAsync<ResponseModel<IdentityTypes>>();
        }


        public async Task<ResponseModel<Profile>> DeleteProfile(int id)
        {
            var response = await _httpClient.DeleteAsync($"/api/Profile/{id}");

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsAsync<ResponseModel<Profile>>();

        }
        public async Task<ResponseModel<ProfileTypes>> DeleteProfileType(int id)
        {
            var response = await _httpClient.DeleteAsync($"/api/ProfileTypes/{id}");

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsAsync<ResponseModel<ProfileTypes>>();
        }

        public async Task<ResponseModel<Statuses>> DeleteStatus(int id)
        {
            var response = await _httpClient.DeleteAsync($"/api/Statuses/{id}");

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsAsync<ResponseModel<Statuses>>();
        }

        public async Task<ResponseModel<TransactionCodes>> DeleteTransactionCode(int id)
        {
            var response = await _httpClient.DeleteAsync($"/api/TransactionCodes/{id}");

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsAsync<ResponseModel<TransactionCodes>>();
        }

        public async Task<ResponseModel<Transactions>> DeleteTransactions(int id)
        {
            var response = await _httpClient.DeleteAsync($"/api/Transactions/{id}");

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsAsync<ResponseModel<Transactions>>();
        }

        public async Task<ResponseModel<Funeral>> GetAllFunerals()
        {
            var response = await _httpClient.GetAsync("/api/sessions");

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsAsync<ResponseModel<Funeral>>();
        }

        public async Task<ResponseModel<IdentityTypes>> GetAllIdentityTypes()
        {
            var response = await _httpClient.GetAsync("/api/IdentityTypes");

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsAsync<ResponseModel<IdentityTypes>>();
        }

        public async Task<ResponseModel<Profile>> GetAllProfiles()
        {
            var response = await _httpClient.GetAsync("/api/Profile");

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsAsync<ResponseModel<Profile>>();
        }

        public async Task<ResponseModel<ProfileTypes>> GetAllProfileTypes()
        {
            var response = await _httpClient.GetAsync("/api/ProfileTypes");

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsAsync<ResponseModel<ProfileTypes>>();
        }

        public async Task<ResponseModel<Statuses>> GetAllStatuses()
        {
            var response = await _httpClient.GetAsync("/api/Statuses");

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsAsync<ResponseModel<Statuses>>();
        }

        public async Task<ResponseModel<TransactionCodes>> GetAllTransactionCodes()
        {
            var response = await _httpClient.GetAsync("/api/TransactionCodes");

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsAsync<ResponseModel<TransactionCodes>>();
        }

        public async Task<ResponseModel<Transactions>> GetAllTransactions()
        {
            var response = await _httpClient.GetAsync("/api/Transactions");

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsAsync<ResponseModel<Transactions>>();
        }

        public async Task<ResponseModel<Funeral>> GetFuneralById(int id)
        {
            var response = await _httpClient.GetAsync($"/api/Funeral/{id}");

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsAsync<ResponseModel<Funeral>>();
        }

        public async Task<ResponseModel<IdentityTypes>> GetIdentityTypeById(int id)
        {
            var response = await _httpClient.GetAsync($"/api/IdentityTypes/{id}");

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsAsync<ResponseModel<IdentityTypes>>();
        }

        public async Task<ResponseModel<Profile>> GetProfileById(int id)
        {
            var response = await _httpClient.GetAsync($"/api/Profile/{id}");

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsAsync<ResponseModel<Profile>>();
        }

        public async Task<ResponseModel<ProfileTypes>> GetProfileTypeById(int id)
        {
            var response = await _httpClient.GetAsync($"/api/ProfileTypes/{id}");

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsAsync<ResponseModel<ProfileTypes>>();
        }

        public async Task<ResponseModel<Statuses>> GetStatusById(int id)
        {
            var response = await _httpClient.GetAsync($"/api/Statuses/{id}");

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsAsync<ResponseModel<Statuses>>();
        }

        public async Task<ResponseModel<Transactions>> GetTransactionById(int id)
        {
            var response = await _httpClient.GetAsync($"/api/Transactions/{id}");

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsAsync<ResponseModel<Transactions>>();
        }

        public async Task<ResponseModel<TransactionCodes>> GetTransactionCodeById(int id)
        {
            var response = await _httpClient.GetAsync($"/api/TransactionCodes/{id}");

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsAsync<ResponseModel<TransactionCodes>>();
        }

        public async Task<ResponseModel<Funeral>> UpdateFuneral(int id, Funeral funeral)
        {
            var response = await _httpClient.PutAsJsonAsync($"/api/Funeral/{id}", funeral);

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsAsync<ResponseModel<Funeral>>();
        }

        public async Task<ResponseModel<IdentityTypes>> UpdateIdentityType(int id, IdentityTypes identityType)
        {
            var response = await _httpClient.PutAsJsonAsync($"/api/IdentityTypes/{id}", identityType);

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsAsync<ResponseModel<IdentityTypes>>();
        }

        public async Task<ResponseModel<Profile>> UpdateProfile(int id, Profile profile)
        {
            var response = await _httpClient.PutAsJsonAsync($"/api/Profile/{id}", profile);

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsAsync<ResponseModel<Profile>>();
        }

        public async Task<ResponseModel<ProfileTypes>> UpdateProfileType(int id, ProfileTypes profileType)
        {
            var response = await _httpClient.PutAsJsonAsync($"/api/ProfileTypes/{id}", profileType);

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsAsync<ResponseModel<ProfileTypes>>();
        }


        public async Task<ResponseModel<Statuses>> UpdateStatus(int id, Statuses status)
        {
            var response = await _httpClient.PutAsJsonAsync($"/api/Statuses/{id}", status);

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsAsync<ResponseModel<Statuses>>();

        }
        public async Task<ResponseModel<TransactionCodes>> UpdateTransactionCode(int id, TransactionCodes transactionCode)
        {
            var response = await _httpClient.PutAsJsonAsync($"/api/TransactionCodes/{id}", transactionCode);

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsAsync<ResponseModel<TransactionCodes>>();
        }

        public async Task<ResponseModel<Transactions>> UpdateTransactions(int id, Transactions transaction)
        {
            var response = await _httpClient.PutAsJsonAsync($"/api/Transactions/{id}", transaction);

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsAsync<ResponseModel<Transactions>>();
        }
    }
}
