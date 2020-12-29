using Munharaunda.Domain.Contracts;
using Munharaunda.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Munharaunda.Web.WebServices
{
    public class ApiClient : IApiClient
    {
        private readonly HttpClient _httpClient;

        public ApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public Task<ResponseModel<Funeral>> CreateFuneral(Funeral funeral)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<IdentityTypes>> CreateIdentityType(IdentityTypes identityType)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<Profile>> CreateProfile(Profile Profile)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<ProfileTypes>> CreateProfileType(ProfileTypes profileType)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<Statuses>> CreateStatuses(Statuses status)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<TransactionCodes>> CreateTransactionCode(TransactionCodes transactionCode)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<Transactions>> CreateTransactions(Transactions transaction)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<Funeral>> DeleteFuneralById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<IdentityTypes>> DeleteIdentityType(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<Profile>> DeleteProfile(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<ProfileTypes>> DeleteProfileType(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<Statuses>> DeleteStatus(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<TransactionCodes>> DeleteTransactionCode(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<Transactions>> DeleteTransactions(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<Funeral>> GetAllFunerals()
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<IdentityTypes>> GetAllIdentityTypes()
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<Profile>> GetAllProfiles()
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<ProfileTypes>> GetAllProfileTypes()
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<Statuses>> GetAllStatuses()
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<TransactionCodes>> GetAllTransactionCodes()
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<Transactions>> GetAllTransactions()
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<Funeral>> GetFuneralById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<IdentityTypes>> GetIdentityTypeById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<Profile>> GetProfileById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<ProfileTypes>> GetProfileTypeById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<Statuses>> GetStatusById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<Transactions>> GetTransactionById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<TransactionCodes>> GetTransactionCodeById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<Funeral>> UpdateFuneral(int id, Funeral funeral)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<IdentityTypes>> UpdateIdentityType(int id, IdentityTypes identityType)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<Profile>> UpdateProfile(int id, Profile Profile)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<ProfileTypes>> UpdateProfileType(int id, ProfileTypes profileType)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<Statuses>> UpdateStatus(int id, Statuses status)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<TransactionCodes>> UpdateTransactionCode(int id, TransactionCodes transactionCode)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<Transactions>> UpdateTransactions(int id, Transactions transaction)
        {
            throw new NotImplementedException();
        }
    }
}
