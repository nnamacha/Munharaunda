using Microsoft.EntityFrameworkCore;
using Munharaunda.Core.Constants;
using Munharaunda.Domain.Contracts;
using Munharaunda.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Munharaunda.Infrastructure.Database
{

    public class MunharaundaRepository : IMunharaundaRepository
    {
        private readonly MunharaundaDbContext _context;
        

        public MunharaundaRepository(MunharaundaDbContext context)
        {
            _context = context;
        }

        #region Initialize
        private static ResponseModel<Funeral> InitializeFuneral()
        {
            var response = new ResponseModel<Funeral>();
            response.ResponseData = new List<Funeral>();
            return response;
        }

        private static ResponseModel<IdentityTypes> InitializeIdType()
        {
            var response = new ResponseModel<IdentityTypes>();
            response.ResponseData = new List<IdentityTypes>();
            return response;
        }

        private static ResponseModel<ProfileTypes> InitializeProfileType()
        {
            var response = new ResponseModel<ProfileTypes>();
            response.ResponseData = new List<ProfileTypes>();
            return response;
        }

        private static ResponseModel<Profile> InitializeProfile()
        {
            var response = new ResponseModel<Profile>();
            response.ResponseData = new List<Profile>();
            return response;
        }

        private static ResponseModel<Statuses> InitializeStatuses()
        {
            var response = new ResponseModel<Statuses>();
            response.ResponseData = new List<Statuses>();
            return response;
        }

        private static ResponseModel<Transactions> InitializeTransactions()
        {
            var response = new ResponseModel<Transactions>();
            response.ResponseData = new List<Transactions>();
            return response;
        }

        private static ResponseModel<TransactionCodes> InitializeTransactionCodes()
        {
            var response = new ResponseModel<TransactionCodes>();
            response.ResponseData = new List<TransactionCodes>();
            return response;
        }

        #endregion

        #region Classwide Methods

        private static ResponseModel<T> GetResponseList<T>(ResponseModel<T> response, List<T> _DbResponse)
        {
            if (_DbResponse.Count == 0)
            {
                response.ResponseCode = ReturnCodesConstant.R06;
                response.ResponseMessage = ReturnCodesConstant.R06Message;

            }
            else
            {
                response.ResponseCode = ReturnCodesConstant.R00;
                response.ResponseMessage = ReturnCodesConstant.R00Message;
                response.ResponseData = _DbResponse;
            }
            return response;
        }

        private static ResponseModel<T> GetResponse<T>(ResponseModel<T> response, T _DbResponse)
        {
            if (_DbResponse == null)
            {
                response.ResponseCode = ReturnCodesConstant.R06;
                response.ResponseMessage = ReturnCodesConstant.R06Message;

            }
            else
            {
                response.ResponseCode = ReturnCodesConstant.R00;
                response.ResponseMessage = ReturnCodesConstant.R00Message;
                response.ResponseData.Add(_DbResponse);
            }
            return response;
        }

        private async Task<ResponseModel<T>> UpdateRecord<T>(int id, T rec, ResponseModel<T> response)
        {

            return await SaveToDb(response);
                
            
        }

        private async Task<ResponseModel<T>> CreateRecord<T>(T rec, ResponseModel<T> response)
        {
            try
            {

                if (typeof(T).Equals(typeof(Profile)))
                {
                    var profile = rec as Profile;
                   
                    _context.Profile.Add(profile);
                    
                }
                else if (typeof(T).Equals(typeof(Funeral)))
                {
                    var funeral = rec as Funeral;
                    _context.Funeral.Add(funeral);
                   
                }
                else if (typeof(T).Equals(typeof(IdentityTypes)))
                {
                    var identityTypes = rec as IdentityTypes;
                    _context.IdentityTypes.Add(identityTypes);
                }
                else if (typeof(T).Equals(typeof(ProfileTypes)))
                {
                    var profileTypes = rec as ProfileTypes;
                    _context.ProfileTypes.Add(profileTypes);
                }
                else if (typeof(T).Equals(typeof(Statuses)))
                {
                    var statuses = rec as Statuses;
                    _context.Statuses.Add(statuses);
                }
                else if (typeof(T).Equals(typeof(TransactionCodes)))
                {
                    var transactionCodes = rec as TransactionCodes;
                    _context.TransactionCodes.Add(transactionCodes);
                }
                else if (typeof(T).Equals(typeof(Transactions)))
                {
                    var transactions = rec as Transactions;
                    _context.Transactions.Add(transactions);
                }
                else
                {
                    throw new ArgumentException("Invalid Type", paramName: nameof(rec));

                }
                              
               

                response = await SaveToDb(response);
                response.ResponseData.Add(rec);
                

            }
            catch (Exception ex)
            {
                response.ResponseCode = ReturnCodesConstant.R99;
                response.ResponseMessage = ex.Message;

            }

            return response;
        }
        private async Task<ResponseModel<T>> DeleteRecord<T>(int id, ResponseModel<T> response)
        {
            response.ResponseCode = ReturnCodesConstant.R06;
            response.ResponseMessage = ReturnCodesConstant.R06Message;

            try
            {
                if (typeof(T).Equals(typeof(Profile)))
                {

                    var profile = await _context.Profile.FindAsync(id);

                    if (profile == null)
                    {
                        return response;
                    }
                    else
                    {
                        _context.Profile.Remove(profile);


                        response = await SaveToDb(response);
                    }


                }
                else if (typeof(T).Equals(typeof(Funeral)))
                {

                    var funeral = await _context.Funeral.FindAsync(id);

                    if (funeral == null)
                    {
                        return response;
                    }
                    else
                    {
                        _context.Funeral.Remove(funeral);
                        response = await SaveToDb(response);
                    }
                }
                else if (typeof(T).Equals(typeof(IdentityTypes)))
                {
                    var identityType = await _context.IdentityTypes.FindAsync(id);

                    if (identityType == null)
                    {
                        return response;
                    }
                    else
                    {
                        _context.IdentityTypes.Remove(identityType);
                        response = await SaveToDb(response);
                    }
                }
                else if (typeof(T).Equals(typeof(ProfileTypes)))
                {
                    var profileType = await _context.ProfileTypes.FindAsync(id);

                    if (profileType == null)
                    {
                        return response;
                    }
                    else
                    {
                        _context.ProfileTypes.Remove(profileType);
                        response = await SaveToDb(response);
                    }
                }
                else if (typeof(T).Equals(typeof(Statuses)))
                {
                    var status = await _context.Statuses.FindAsync(id);

                    if (status == null)
                    {
                        return response;
                    }
                    else
                    {
                        _context.Statuses.Remove(status);
                        response = await SaveToDb(response);
                    }
                }
                else if (typeof(T).Equals(typeof(TransactionCodes)))
                {
                    var transactionCode = await _context.TransactionCodes.FindAsync(id);

                    if (transactionCode == null)
                    {
                        return response;
                    }
                    else
                    {
                        _context.TransactionCodes.Remove(transactionCode);
                        response = await SaveToDb(response);
                    }
                }
                else if (typeof(T).Equals(typeof(Transactions)))
                {
                    var transaction = await _context.Transactions.FindAsync(id);

                    if (transaction == null)
                    {
                        return response;
                    }
                    else
                    {
                        _context.Transactions.Remove(transaction);
                        response = await SaveToDb(response);
                    }
                }
                else
                {
                    throw new ArgumentException("Invalid Type", paramName: nameof(response));

                }







            }
            catch (Exception ex)
            {

                response.ResponseCode = ReturnCodesConstant.R99;
                response.ResponseMessage = ex.Message;
            }
            return response;
        }

        private async Task<ResponseModel<T>> SaveToDb<T>(ResponseModel<T> response)
        {

            try
            {
                var _dbResponse = await _context.SaveChangesAsync();

                if (_dbResponse > 0)
                {
                    response.ResponseCode = ReturnCodesConstant.R00;
                    response.ResponseMessage = ReturnCodesConstant.R00Message;
                    

                }
                else
                {
                    response.ResponseCode = ReturnCodesConstant.R05;
                    response.ResponseMessage = ReturnCodesConstant.R05Message;
                }
            }
            catch (Exception ex)
            {

                response.ResponseCode = ReturnCodesConstant.R99;
                response.ResponseMessage = ex.Message;
            }

            return response;

        }
        #endregion

        #region ProfileController


        private async Task<ProfileResponse> GenerateProfileDetails(Profile profile)
        {
            return new ProfileResponse
            {
                ProfileNumber = profile.ProfileNumber,
                ProfileType = await GetProfileType(profile.ProfileTypeId),
                FullName = profile.Name + " " + profile.Surname,
                IdentityType = await GetIdentityTypes(profile.IdentityTypeId),
                IdentityNumber = profile.IdentityNumber,
                DateOfBirth = profile.DateOfBirth,
                PhoneNumber = profile.PhoneNumber,
                PaidFuneral = await GetPaidFunerals(profile.ProfileNumber),
                StatusDescription = await GetStatus(profile.Status),
                Address = profile.Address,
                ActiveDate = profile.ActiveDate,
                NextOfKin = profile.NextOfKin,
                Created = profile.Created,
                CreatedBy = profile.CreatedBy,
                Updated = profile.Updated,
                UpdatedBy = profile.UpdatedBy

            };
        }

        public async Task<ICollection<Funeral>> GetPaidFunerals(int profileId)
        {
            var Funerals = new List<Funeral>();
            var transactions = await _context.Transactions.Where(f => f.Contribution == true && f.CreatedBy == profileId).ToListAsync();

            foreach (var item in transactions)
            {
                var funeral = await GetFuneral(item.FuneralId);

                if (funeral != null)
                {
                    foreach (var i in funeral.ResponseData)
                    {
                        Funerals.Add(i);
                    }

                }

            }

            return Funerals;
        }

        private async Task<IdentityTypes> GetIdentityTypes(int id)
        {
            var identityTypes = await _context.IdentityTypes.FindAsync(id);

            return identityTypes;
        }

        private async Task<ProfileTypes> GetProfileType(int id)
        {
            var profileTypes = await _context.ProfileTypes.FindAsync(id);

            return profileTypes;
        }
        private async Task<string> GetStatus(int id)
        {

            var status = await _context.Statuses.FindAsync(id);

            if (status == null)
            {
                return "No Status Found";
            }

            return status.StatusDescription;
        }

        public async Task<ResponseModel<Profile>> GetProfile(int id)
        {
            ResponseModel<Profile> response = InitializeProfile();

            try
            {

                var _DbResponse = await _context.Profile.FindAsync(id);
                response = GetResponse(response, _DbResponse);


            }
            catch (Exception ex)
            {

                response.ResponseCode = ReturnCodesConstant.R99;
                response.ResponseMessage = ex.Message;


            }





            return response;
        }

        public async Task<ResponseModel<Profile>> GetProfiles()
        {
            ResponseModel<Profile> response = InitializeProfile();



            try
            {
                var _DbResponse = await _context.Profile.ToListAsync();

                response = GetResponseList(response, _DbResponse);

            }
            catch (Exception ex)
            {

                response.ResponseCode = ReturnCodesConstant.R99;
                response.ResponseMessage = ex.Message;
            }
            return response;
        }

        

        public async Task<ResponseModel<Profile>> UpdateProfile(int id, Profile profile)
        {

            ResponseModel<Profile> response = InitializeProfile();

            _context.Entry(profile).State = EntityState.Modified;

            
            return await UpdateRecord(id, profile, response);
        }

        

        public async Task<ResponseModel<Profile>> CreateProfile(Profile profile)
        {

            ResponseModel<Profile> response = InitializeProfile();

            return await CreateRecord(profile, response);
        }

        

        public async Task<ResponseModel<Profile>> DeleteProfile(int id)
        {
            ResponseModel<Profile> response = InitializeProfile();

            return await DeleteRecord(id, response);
        }

        

        

        public bool ProfileExists(int id)
        {
            return _context.Profile.Any(e => e.ProfileNumber == id);
        }

        

        #endregion

        #region FuneralController

        public async Task<ResponseModel<Funeral>> GetFunerals()
        {

            ResponseModel<Funeral> response = InitializeFuneral();

            try
            {
                var dbResponse = await _context.Funeral.ToListAsync();
                response = GetResponseList(response, dbResponse);

            }
            catch (Exception ex)
            {

                response.ResponseCode = ReturnCodesConstant.R99;
                response.ResponseMessage = ex.Message;
            }



            return response;

        }

        
        public async Task<ResponseModel<Funeral>> GetFuneral(int id)
        {
            ResponseModel<Funeral> response = InitializeFuneral();
            try
            {
                var dbResponse = await _context.Funeral.FindAsync(id);

                response = GetResponse(response, dbResponse);

                //if (dbResponse == null)
                //{
                //    response.ResponseCode = ReturnCodesConstant.R06;
                //    response.ResponseMessage = ReturnCodesConstant.R06Message;

                //}
                //else
                //{
                //    response.ResponseCode = ReturnCodesConstant.R00;
                //    response.ResponseMessage = ReturnCodesConstant.R00Message;
                //    response.ResponseData.Add(dbResponse);
                //}


            }

            catch (Exception ex)
            {

                response.ResponseCode = ReturnCodesConstant.R99;
                response.ResponseMessage = ex.Message;

            }

            return response;

        }

        public async Task<ResponseModel<Funeral>> UpdateFuneral(int id, Funeral funeral)
        {
            ResponseModel<Funeral> response = InitializeFuneral();

            
                _context.Entry(funeral).State = EntityState.Modified;              

                response = await UpdateRecord(id, funeral, response);

                //if (dbResponse > 0)
                //{
                //    response.ResponseCode = ReturnCodesConstant.R00;
                //    response.ResponseMessage = ReturnCodesConstant.R00Message;
                //    response.ResponseData.Add(funeral);
                //}
                //else
                //{
                //    response.ResponseCode = ReturnCodesConstant.R05;
                //    response.ResponseMessage = ReturnCodesConstant.R05Message + "Funeral Not Updated";
                //}

            

            return response;
        }

        public async Task<ResponseModel<Funeral>> CreateFuneral(Funeral funeral)
        {
            ResponseModel<Funeral> response = InitializeFuneral();

            return await CreateRecord(funeral, response);

           
        }

        public async Task<ResponseModel<Funeral>> DeleteFuneral(int id)
        {
            ResponseModel<Funeral> response = InitializeFuneral();

            try
            {
                var dbResponse = await GetFuneral(id);

                return await DeleteRecord(id, response);

                //if (dbResponse.ResponseCode == ReturnCodesConstant.R00)
                //{
                //    _context.Funeral.Remove(dbResponse.ResponseData[0]);
                //    var _response = await _context.SaveChangesAsync();

                //    if (_response > 0)
                //    {
                //        response.ResponseCode = ReturnCodesConstant.R00;
                //        response.ResponseMessage = ReturnCodesConstant.R00Message;
                //    }
                //    else
                //    {
                //        response.ResponseCode = ReturnCodesConstant.R05;
                //        response.ResponseMessage = ReturnCodesConstant.R05Message + " Record not deleted";
                //    }

                //}

            }
            catch (Exception ex)
            {

                response.ResponseCode = ReturnCodesConstant.R99;
                response.ResponseMessage = ex.Message;
            }
            return response;
        }

        #endregion

        #region IdentityTypesController

        public async Task<ResponseModel<IdentityTypes>> GetIdentityTypes()
        {
            ResponseModel<IdentityTypes> response = InitializeIdType();
            try
            {
                var dbResponse = await _context.IdentityTypes.ToListAsync();
                response = GetResponseList(response, dbResponse);
            }
            catch (Exception ex)
            {

                response.ResponseCode = ReturnCodesConstant.R99;
                response.ResponseMessage = ex.Message;
            }

            return response;
        }

        public async Task<ResponseModel<IdentityTypes>> GetIdentityType(int id)
        {
            ResponseModel<IdentityTypes> response = InitializeIdType();
            try
            {
                var dbResponse = await _context.IdentityTypes.FindAsync(id);

                response = GetResponse(response, dbResponse);
            
            }
            catch (Exception ex)
            {

                response.ResponseCode = ReturnCodesConstant.R99;
                response.ResponseMessage = ex.Message;
            }

            return response;
        }

        public async Task<ResponseModel<IdentityTypes>> UpdateIdentityType(int id, IdentityTypes identityType)
        {
            ResponseModel<IdentityTypes> response = InitializeIdType();

            _context.Entry(identityType).State = EntityState.Modified;

            return await UpdateRecord(id, identityType, response);
           
            
        }

        public async Task<ResponseModel<IdentityTypes>> CreateIdentityType(IdentityTypes identityType)
        {
            ResponseModel<IdentityTypes> response = InitializeIdType();

            return await CreateRecord(identityType, response);

            
        }

        public async Task<ResponseModel<IdentityTypes>> DeleteIdentityType(int id)
        {
            ResponseModel<IdentityTypes> response = InitializeIdType();

            return await DeleteRecord(id, response);
        }




        #endregion

        #region ProfileTypeController

        public async Task<ResponseModel<ProfileTypes>> GetProfileTypes()
        {
            ResponseModel<ProfileTypes> response = InitializeProfileType();

            try
            {
                var dbResponse = await _context.ProfileTypes.ToListAsync();

                response = GetResponseList(response, dbResponse);
            }
            catch (Exception ex)
            {

                response.ResponseCode = ReturnCodesConstant.R99;
                response.ResponseMessage = ex.Message;
            }

            return response;
        }

        public async Task<ResponseModel<ProfileTypes>> GetProfileTypes(int id)
        {
            ResponseModel<ProfileTypes> response = InitializeProfileType();

            try
            {
                var dbResponse = await _context.ProfileTypes.FindAsync(id);

                response = GetResponse(response, dbResponse);
            }
            catch (Exception ex)
            {

                response.ResponseCode = ReturnCodesConstant.R99;
                response.ResponseMessage = ex.Message;
            }
            return response;
        }

        public async Task<ResponseModel<ProfileTypes>> UpdateProfileType(int id, ProfileTypes profileTypes)
        {
            ResponseModel<ProfileTypes> response = InitializeProfileType();

            _context.Entry(profileTypes).State = EntityState.Modified;

            return await UpdateRecord(id, profileTypes, response);
        }

        public async Task<ResponseModel<ProfileTypes>> CreateProfileType(ProfileTypes profileTypes)
        {
            ResponseModel<ProfileTypes> response = InitializeProfileType();

            return await CreateRecord(profileTypes, response);
        }

        public async Task<ResponseModel<ProfileTypes>> DeleteProfileType(int id)
        {
            ResponseModel<ProfileTypes> response = InitializeProfileType();

            return await DeleteRecord(id, response);
        }

        #endregion

        #region StatusController

        public async Task<ResponseModel<Statuses>> GetStatuses()
        {
            ResponseModel<Statuses> response = InitializeStatuses();

            try
            {
                var dbResponse = await _context.Statuses.ToListAsync();

                response = GetResponseList(response, dbResponse);
            }
            catch (Exception ex)
            {

                response.ResponseCode = ReturnCodesConstant.R99;
                response.ResponseMessage = ex.Message;
            }
            return response;
        }

        public async Task<ResponseModel<Statuses>> GetStatuses(int id)
        {
            ResponseModel<Statuses> response = InitializeStatuses();

            try
            {
                var dbResponse = await _context.Statuses.FindAsync(id);

                response = GetResponse(response, dbResponse);
            }
            catch (Exception ex)
            {

                response.ResponseCode = ReturnCodesConstant.R99;
                response.ResponseMessage = ex.Message;
            }
            return response;
        }

        public async Task<ResponseModel<Statuses>> UpdateStatuses(int id, Statuses statuses)
        {
            ResponseModel<Statuses> response = InitializeStatuses();

            _context.Entry(statuses).State = EntityState.Modified;

            return await UpdateRecord(id, statuses, response);

        }

        public async Task<ResponseModel<Statuses>> CreateStatus(Statuses statuses)
        {
            ResponseModel<Statuses> response = InitializeStatuses();

            return await CreateRecord(statuses, response);
        }

        public async Task<ResponseModel<Statuses>> DeleteStatus(int id)
        {
            ResponseModel<Statuses> response = InitializeStatuses();

            return await DeleteRecord(id, response);
        }
        

        private bool StatusesExists(int id)
        {
            return _context.Statuses.Any(e => e.StatusId == id);
        }
        #endregion

        #region TransactionsController

        public async Task<ResponseModel<Transactions>> GetTransactions()
        {
            ResponseModel<Transactions> response = InitializeTransactions();

            try
            {
                var dbResponse = await _context.Transactions.ToListAsync();

                response = GetResponseList(response, dbResponse);
            }
            catch (Exception ex)
            {

                response.ResponseCode = ReturnCodesConstant.R99;
                response.ResponseMessage = ex.Message;
            }
            return response;
        }

        public async Task<ResponseModel<Transactions>> GetTransaction(int id)
        {
            ResponseModel<Transactions> response = InitializeTransactions();

            try
            {
                var dbResponse = await _context.Transactions.FindAsync(id);

                response = GetResponse(response, dbResponse);
            }
            catch (Exception ex)
            {

                response.ResponseCode = ReturnCodesConstant.R99;
                response.ResponseMessage = ex.Message;
            }
            return response;
        }

        public async Task<ResponseModel<Transactions>> UpdateTransactions(int id, Transactions Transaction)
        {
            ResponseModel<Transactions> response = InitializeTransactions();

            _context.Entry(Transaction).State = EntityState.Modified;

            return await UpdateRecord(id, Transaction, response);            

        }

        public async Task<ResponseModel<Transactions>> CreateTransaction(Transactions transaction)
        {
            ResponseModel<Transactions> response = InitializeTransactions();

            return await CreateRecord(transaction, response);
        }

        public async Task<ResponseModel<Transactions>> DeleteTransaction(int id)
        {
            ResponseModel<Transactions> response = InitializeTransactions();

            return await DeleteRecord(id, response);
        }

        

        #endregion

        #region TransactionCodesController

        public async Task<ResponseModel<TransactionCodes>> GetTransactionCodes()
        {
            ResponseModel<TransactionCodes> response = InitializeTransactionCodes();

            try
            {
                var dbResponse = await _context.TransactionCodes.ToListAsync();

                response = GetResponseList(response, dbResponse);
            }
            catch (Exception ex)
            {

                response.ResponseCode = ReturnCodesConstant.R99;
                response.ResponseMessage = ex.Message;
            }
            return response;
        }

        public async Task<ResponseModel<TransactionCodes>> GetTransactionCode(int id)
        {
            ResponseModel<TransactionCodes> response = InitializeTransactionCodes();

            try
            {
                var dbResponse = await _context.TransactionCodes.FindAsync(id);

                response = GetResponse(response, dbResponse);
            }
            catch (Exception ex)
            {

                response.ResponseCode = ReturnCodesConstant.R99;
                response.ResponseMessage = ex.Message;
            }
            return response;
        }

        public async Task<ResponseModel<TransactionCodes>> UpdateTransactionCodes(int id, TransactionCodes TransactionCode)
        {
            ResponseModel<TransactionCodes> response = InitializeTransactionCodes();

            _context.Entry(TransactionCode).State = EntityState.Modified;

            return await UpdateRecord(id, TransactionCode, response);

        }

        public async Task<ResponseModel<TransactionCodes>> CreateTransactionCode(TransactionCodes transactionCode)
        {
            ResponseModel<TransactionCodes> response = InitializeTransactionCodes();

            return await CreateRecord(transactionCode, response);
        }

        public async Task<ResponseModel<TransactionCodes>> DeleteTransactionCode(int id)
        {
            ResponseModel<TransactionCodes> response = InitializeTransactionCodes();

            return await DeleteRecord(id, response);
        }

        #endregion


    }
}
