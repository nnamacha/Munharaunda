using Munharaunda.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Munharaunda.Domain.Contracts
{
    public interface IApiClient
    {
        Task<ResponseModel<Funeral>> GetAllFunerals();
        Task<ResponseModel<Funeral>> GetFuneralById(int id);
        Task<ResponseModel<Funeral>> UpdateFuneral(int id, Funeral funeral);
        Task<ResponseModel<Funeral>> CreateFuneral(Funeral funeral);
        Task<ResponseModel<Funeral>> DeleteFuneralById(int id);

        Task<ResponseModel<IdentityTypes>> GetAllIdentityTypes();
        Task<ResponseModel<IdentityTypes>> GetIdentityTypeById(int id);
        Task<ResponseModel<IdentityTypes>> CreateIdentityType(IdentityTypes identityType);
        Task<ResponseModel<IdentityTypes>> UpdateIdentityType(int id, IdentityTypes identityType);
        Task<ResponseModel<IdentityTypes>> DeleteIdentityType(int id);

        Task<ResponseModel<Profile>> GetAllProfiles();
        Task<ResponseModel<Profile>> GetProfileById(int id);
        Task<ResponseModel<Profile>> CreateProfile(Profile Profile);
        Task<ResponseModel<Profile>> UpdateProfile(int id, Profile Profile);
        Task<ResponseModel<Profile>> DeleteProfile(int id);

        Task<ResponseModel<ProfileTypes>> GetAllProfileTypes();
        Task<ResponseModel<ProfileTypes>> GetProfileTypeById(int id);
        Task<ResponseModel<ProfileTypes>> CreateProfileType(ProfileTypes profileType);
        Task<ResponseModel<ProfileTypes>> UpdateProfileType(int id, ProfileTypes profileType);
        Task<ResponseModel<ProfileTypes>> DeleteProfileType(int id);

        Task<ResponseModel<Statuses>> GetAllStatuses();
        Task<ResponseModel<Statuses>> GetStatusById(int id);
        Task<ResponseModel<Statuses>> CreateStatuses(Statuses status);
        Task<ResponseModel<Statuses>> UpdateStatus(int id, Statuses status);
        Task<ResponseModel<Statuses>> DeleteStatus(int id);

        Task<ResponseModel<TransactionCodes>> GetAllTransactionCodes();
        Task<ResponseModel<TransactionCodes>> GetTransactionCodeById(int id);
        Task<ResponseModel<TransactionCodes>> CreateTransactionCode(TransactionCodes transactionCode);
        Task<ResponseModel<TransactionCodes>> UpdateTransactionCode(int id, TransactionCodes transactionCode);
        Task<ResponseModel<TransactionCodes>> DeleteTransactionCode(int id);

        Task<ResponseModel<Transactions>> GetAllTransactions();
        Task<ResponseModel<Transactions>> GetTransactionById(int id);
        Task<ResponseModel<Transactions>> CreateTransactions(Transactions transaction);
        Task<ResponseModel<Transactions>> UpdateTransactions(int id, Transactions transaction);
        Task<ResponseModel<Transactions>> DeleteTransactions(int id);


    }
}
