﻿using Munharaunda.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Munharaunda.Domain.Contracts
{
    public interface IMunharaundaRepository
    {
        Task<ResponseModel<Funeral>> GetFuneral(int id);
        Task<ICollection<Funeral>> GetPaidFunerals(int profileId);
        Task<ResponseModel<ProfileResponse>> GetProfile(int id);
        Task<IEnumerable<ProfileResponse>> GetProfiles();
        Task<ResponseModel<Profile>> UpdateProfile(int id, Profile profile);
        bool ProfileExists(int id);
        Task<ResponseModel<Profile>> CreateProfile(Profile profile);
        Task<ResponseModel<string>> DeleteProfile(int id);

        Task<ResponseModel<Funeral>> GetFunerals();
        Task<ResponseModel<Funeral>> UpdateFuneral(int id, Funeral funeral);
        Task<ResponseModel<Funeral>> CreateFuneral(Funeral funeral);
        Task<ResponseModel<Funeral>> DeleteFuneral(int id);
        bool FuneralExists(int id);

        Task<ResponseModel<IdentityTypes>> GetIdentityTypes();
        Task<ResponseModel<IdentityTypes>> GetIdentityType(int id);
        Task<ResponseModel<IdentityTypes>> UpdateIdentityType(int id, IdentityTypes identityType);
        Task<ResponseModel<IdentityTypes>> CreateIdentityType(IdentityTypes identityType);
        Task<ResponseModel<IdentityTypes>> DeleteIdentityType(int id);
        public bool IdentityTypeExists(int id);

        Task<ResponseModel<ProfileTypes>> GetProfileTypes();
        Task<ResponseModel<ProfileTypes>> GetProfileTypes(int id);

        bool ProfileTypesExists(int id);

        Task<ResponseModel<ProfileTypes>> UpdateProfileType(int id, ProfileTypes profileTypes);
        Task<ResponseModel<ProfileTypes>> CreateProfileType(ProfileTypes profileTypes);
        Task<ResponseModel<ProfileTypes>> DeleteProfileType(int id);
        Task<ResponseModel<Statuses>> GetStatuses();
        Task<ResponseModel<Statuses>> GetStatuses(int id);

        Task<ResponseModel<Statuses>> UpdateStatuses(int id, Statuses statuses);
        Task<ResponseModel<Statuses>> CreateStatus(Statuses statuses);
        Task<ResponseModel<Statuses>> DeleteStatus(int id);

        Task<ResponseModel<Transactions>> GetTransactions();
        Task<ResponseModel<Transactions>> GetTransaction(int id);
        Task<ResponseModel<Transactions>> UpdateTransactions(int id, Transactions Transaction);
        Task<ResponseModel<Transactions>> CreateTransaction(Transactions transaction);
        Task<ResponseModel<Transactions>> DeleteTransaction(int id);

        Task<ResponseModel<TransactionCodes>> GetTransactionCodes();
        Task<ResponseModel<TransactionCodes>> GetTransactionCode(int id);
        Task<ResponseModel<TransactionCodes>> UpdateTransactionCodes(int id, TransactionCodes TransactionCode);
        Task<ResponseModel<TransactionCodes>> CreateTransactionCode(TransactionCodes transactionCode);
        Task<ResponseModel<TransactionCodes>> DeleteTransactionCode(int id);

    }
}
