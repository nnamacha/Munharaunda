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
        private readonly IMunharaundaRepository _db;
        private String typeName;


        public ApiClient(HttpClient httpClient, IMunharaundaRepository db)
        {
            _httpClient = httpClient;
            _db = db;
        }

        #region Private Methods

        private async Task<ResponseModel<T>> CallCreate<T>(T rec)
        {
            typeName = typeof(T).Name; ;

            var response = await _httpClient.PostAsJsonAsync($"/api/{typeName}", rec);

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsAsync<ResponseModel<T>>();
        }

        private async Task<ResponseModel<T>> CallDelete<T>(int id)
        {
            typeName = typeof(T).Name;

            var response = await _httpClient.DeleteAsync($"/api/{typeName}/{id}");

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsAsync<ResponseModel<T>>();
        }

        private async Task<ResponseModel<T>> CallGetAll<T>()
        {
            typeName = typeof(T).Name;
            var response = await _httpClient.GetAsync($"/api/{typeName}");

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsAsync<ResponseModel<T>>();
        }

        private async Task<ResponseModel<T>> CallGetById<T>(int id)
        {
            typeName = typeof(T).Name;
            var response = await _httpClient.GetAsync($"/api/{typeName}/{id}");

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsAsync<ResponseModel<T>>();
        }

        private async Task<ResponseModel<T>> CallUpdate<T>(int id, T rec)
        {
            typeName = typeof(T).Name;

            var response = await _httpClient.PutAsJsonAsync($"/api/{typeName}/{id}", rec);

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsAsync<ResponseModel<T>>();
        }
        #endregion

        public async Task<ResponseModel<Funeral>> CreateFuneral(Funeral funeral)
        {
            return await CallCreate<Funeral>(funeral);
        }

        public async Task<ResponseModel<IdentityTypes>> CreateIdentityType(IdentityTypes identityType)
        {
            return await CallCreate<IdentityTypes>(identityType);
        }

        public async Task<ResponseModel<Profile>> CreateProfile(Profile profile)
        {
            return await CallCreate<Profile>(profile);
        }

        public async Task<ResponseModel<ProfileTypes>> CreateProfileType(ProfileTypes profileType)
        {
            return await CallCreate<ProfileTypes>(profileType);
        }

        public async Task<ResponseModel<Statuses>> CreateStatuses(Statuses status)
        {
            return await CallCreate<Statuses>(status);
        }

        public async Task<ResponseModel<TransactionCodes>> CreateTransactionCode(TransactionCodes transactionCode)
        {
            return await CallCreate<TransactionCodes>(transactionCode);
        }

        public async Task<ResponseModel<Transactions>> CreateTransactions(Transactions transaction)
        {
            return await CallCreate<Transactions>(transaction);
        }

        public async Task<ResponseModel<Funeral>> DeleteFuneralById(int id)
        {
            return await CallDelete<Funeral>(id);
        }

        

        public async Task<ResponseModel<IdentityTypes>> DeleteIdentityType(int id)
        {
            return await CallDelete<IdentityTypes>(id);
        }


        public async Task<ResponseModel<Profile>> DeleteProfile(int id)
        {
            return await CallDelete<Profile>(id);

        }
        public async Task<ResponseModel<ProfileTypes>> DeleteProfileType(int id)
        {
            return await CallDelete<ProfileTypes>(id);
        }

        public async Task<ResponseModel<Statuses>> DeleteStatus(int id)
        {
            return await CallDelete<Statuses>(id);
        }

        public async Task<ResponseModel<TransactionCodes>> DeleteTransactionCode(int id)
        {
            return await CallDelete<TransactionCodes>(id);
        }

        public async Task<ResponseModel<Transactions>> DeleteTransactions(int id)
        {
            return await CallDelete<Transactions>(id);
        }

        public async Task<ResponseModel<Funeral>> GetAllFunerals()
        {
            
            return await CallGetAll<Funeral>();
        }

        public async Task<ResponseModel<ActiveFuneralResponse>> GetActiveFunerals()
        {

            
            var response = await _httpClient.GetAsync($"/api/Funeral/Active");

            if (response.StatusCode == HttpStatusCode.InternalServerError)
            {
                response.EnsureSuccessStatusCode();
            }

           
            
                

            return await response.Content.ReadAsAsync<ResponseModel<ActiveFuneralResponse>>();
        }

        public async Task<ResponseModel<ActiveFuneralResponse>> GetFuneralsPaidByProfile(int id, bool paid)
        {


            var response = await _httpClient.GetAsync($"/api/Reports/FuneralsPaidByProfile/{id}/{paid}");

            if (response.StatusCode == HttpStatusCode.InternalServerError)
            {
                response.EnsureSuccessStatusCode();
            }





            return await response.Content.ReadAsAsync<ResponseModel<ActiveFuneralResponse>>();
        }


        public async Task<ResponseModel<IdentityTypes>> GetAllIdentityTypes()
        {
            return await CallGetAll<IdentityTypes>();
        }

        public async Task<ResponseModel<ProfileResponse>> GetAllProfiles()
        {
            ResponseModel<ProfileResponse> response = new ResponseModel<ProfileResponse>
            {
                ResponseData = new List<ProfileResponse>()
            };

            var dbResponse = await CallGetAll<Profile>();

            foreach (var item in dbResponse.ResponseData)
            {
                var profileResponse = await _db.GenerateProfileDetails(item);
                response.ResponseData.Add(profileResponse);
            }
            response.ResponseCode = dbResponse.ResponseCode;
            response.ResponseMessage = dbResponse.ResponseMessage;
            return response;
        }

        public async Task<ResponseModel<ProfileTypes>> GetAllProfileTypes()
        {
            return await CallGetAll<ProfileTypes>();
        }

        public async Task<ResponseModel<Statuses>> GetAllStatuses()
        {
            return await CallGetAll<Statuses>();
        }

        public async Task<ResponseModel<TransactionCodes>> GetAllTransactionCodes()
        {
            return await CallGetAll<TransactionCodes>();
        }

        public async Task<ResponseModel<Transactions>> GetAllTransactions()
        {
            return await CallGetAll<Transactions>();
        }

        public async Task<ResponseModel<Funeral>> GetFuneralById(int id)
        {
            return await CallGetById<Funeral>(id);
        }

        

        public async Task<ResponseModel<IdentityTypes>> GetIdentityTypeById(int id)
        {
            return await CallGetById<IdentityTypes>(id);
        }

        public async Task<ResponseModel<Profile>> GetProfileById(int id)
        {
            return await CallGetById<Profile>(id);
        }

        public async Task<ResponseModel<ProfileTypes>> GetProfileTypeById(int id)
        {
            return await CallGetById<ProfileTypes>(id);
        }

        public async Task<ResponseModel<Statuses>> GetStatusById(int id)
        {
            return await CallGetById<Statuses>(id);
        }

        public async Task<ResponseModel<Transactions>> GetTransactionById(int id)
        {
            return await CallGetById<Transactions>(id);
        }

        public async Task<ResponseModel<TransactionCodes>> GetTransactionCodeById(int id)
        {
            return await CallGetById<TransactionCodes>(id);
        }

        public async Task<ResponseModel<Funeral>> UpdateFuneral(int id, Funeral funeral)
        {
            return await CallUpdate<Funeral>(id, funeral);
        }

        

        public async Task<ResponseModel<IdentityTypes>> UpdateIdentityType(int id, IdentityTypes identityType)
        {
            return await CallUpdate<IdentityTypes>(id, identityType);
        }

        public async Task<ResponseModel<Profile>> UpdateProfile(int id, Profile profile)
        {
            return await CallUpdate<Profile>(id, profile);
        }

        public async Task<ResponseModel<ProfileTypes>> UpdateProfileType(int id, ProfileTypes profileType)
        {
            return await CallUpdate<ProfileTypes>(id, profileType);
        }


        public async Task<ResponseModel<Statuses>> UpdateStatus(int id, Statuses status)
        {
            return await CallUpdate<Statuses>(id, status);

        }
        public async Task<ResponseModel<TransactionCodes>> UpdateTransactionCode(int id, TransactionCodes transactionCode)
        {
            return await CallUpdate<TransactionCodes>(id, transactionCode);
        }

        public async Task<ResponseModel<Transactions>> UpdateTransactions(int id, Transactions transaction)
        {
            return await CallUpdate<Transactions>(id, transaction);
        }
    }
}
