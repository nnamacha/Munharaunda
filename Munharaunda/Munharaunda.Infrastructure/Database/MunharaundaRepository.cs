using Microsoft.EntityFrameworkCore;
using Munharaunda.Core.Constants;
using Munharaunda.Domain.Contracts;
using Munharaunda.Domain.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Munharaunda.Infrastructure.Database
{

    public class MunharaundaRepository : IMunharaundaRepository
    {
      
        private readonly MunharaundaDbContext _context;
        private readonly ICommonUtilities _util;

        public MunharaundaRepository(MunharaundaDbContext context , ICommonUtilities util)
        {
            _context = context;
            _util = util;
        }

        #region Initialize
        private static ResponseModel<Funeral> InitializeFuneral()
        {
            var response = new ResponseModel<Funeral>();
            response.ResponseData = new List<Funeral>();
            return response;
        }

        private static ResponseModel<ActiveFuneralResponse> InitializeActiveFuneral()
        {
            ResponseModel<ActiveFuneralResponse> response = new ResponseModel<ActiveFuneralResponse>();
            response.ResponseData = new List<ActiveFuneralResponse>();
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


        public async Task<ResponseModel<ProfileResponse>> GenerateProfileDetails(Profile profile)
        {
            var response = new ResponseModel<ProfileResponse>();
            response.ResponseData = new List<ProfileResponse>();
            try
            {
                var profileResponse = new ProfileResponse
                {                
                    ProfileNumber = profile.ProfileNumber,
                    ProfileType = await GetProfileType(profile.ProfileTypeId),
                    FullName = profile.Name + " " + profile.Surname,
                    IdentityType = await GetIdentityTypes(profile.IdentityTypeId),
                    IdentityNumber = profile.IdentityNumber,
                    DateOfBirth = profile.DateOfBirth,
                    PhoneNumber = profile.PhoneNumber,
                    Funerals = await GetFunerals(profile.ProfileNumber),                    
                    StatusDescription = await GetStatus(profile.Status),
                    Address = profile.Address,
                    ActiveDate = profile.ActiveDate,
                    NextOfKin = profile.NextOfKin,
                    Created = profile.Created,
                    CreatedBy = profile.CreatedBy,
                    Updated = profile.Updated,
                    UpdatedBy = profile.UpdatedBy

                };
                response.ResponseData.Add(profileResponse);
                response.ResponseCode = ReturnCodesConstant.R00;
                response.ResponseMessage = ReturnCodesConstant.R00Message;
            }
            catch (Exception ex)
            {

                response.ResponseCode = ReturnCodesConstant.R99;
                response.ResponseMessage = ex.Message;
            }

            return response;
            
        }

        public async Task<ICollection<ActiveFuneralResponse>> GetFunerals(int profileId)
        {
            var response = new List<ActiveFuneralResponse>();

            var profile =  await _context.Profile.FindAsync(profileId);

            if (profile != null)
            {
                var profileCreateDate = profile.Created;

                
                var funerals = await _context.Funeral.Where(f => f.Created > profileCreateDate).ToListAsync();
                

                foreach (var funeral in funerals)
                {
                    var transactions = await _context.Transactions.Where(f => f.Contribution == true && f.CreatedBy == profileId && f.FuneralId == funeral.FuneralId).ToListAsync();

                    if (transactions.Count > 0)
                    {
                        return await GetFuneralDetails(funeral, true);
                    }
                    else
                    {
                        return await GetFuneralDetails(funeral, false);
                    }
                }
            }
            

            return response;
        }

        private async Task<List<ActiveFuneralResponse>>GetFuneralDetails(Funeral funeral, bool contributed)
        {
            var response = new List<ActiveFuneralResponse>();
            var funeralDetails = await GetFuneral(funeral.FuneralId);

            if (funeralDetails != null)
            {

                foreach (var i in funeralDetails.ResponseData)
                {
                    var activeFuneralResponse = new ActiveFuneralResponse();

                    var deceasedProfile = await _context.Profile.FindAsync(i.DeceasedsProfileNumber);
                    activeFuneralResponse.DeceasedFullName = deceasedProfile.Name + " " + deceasedProfile.Surname;
                    activeFuneralResponse.DeceasedsProfileNumber = i.DeceasedsProfileNumber;
                    activeFuneralResponse.Created = i.Created;
                    activeFuneralResponse.Contributed = contributed;
                    response.Add(activeFuneralResponse);
                }

            }

            return response;
        }

        public async Task<ICollection<ActiveFuneralResponse>> GetPaidFunerals(int profileId)
        {
            var Funerals = new List<ActiveFuneralResponse>();
            var transactions = await _context.Transactions.Where(f => f.Contribution == true && f.CreatedBy == profileId).ToListAsync();


            foreach (var item in transactions)
            {
                var funeral = await GetFuneral(item.FuneralId);

                if (funeral != null)
                {
                    
                    foreach (var i in funeral.ResponseData)
                    {
                        var funeralDetail = new ActiveFuneralResponse();
                        

                        funeralDetail.DeceasedFullName = _context.Profile.Find(i.DeceasedsProfileNumber).Name + " " + _context.Profile.Find(i.DeceasedsProfileNumber).Surname;
                        funeralDetail.DeceasedsProfileNumber = i.DeceasedsProfileNumber;
                        funeralDetail.Created = i.Created;
                        Funerals.Add(funeralDetail);
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

        public async Task<ResponseModel<ActiveFuneralResponse>> GetActiveFuneral()
        {

            ResponseModel<ActiveFuneralResponse> response = InitializeActiveFuneral();
            List<ActiveFuneralResponse> dbResponse = new List<ActiveFuneralResponse>();

            try
            {
                var activeStatus = await _context.Statuses.Where(s => s.StatusDescription == "Active").FirstOrDefaultAsync();

                if (activeStatus == null)
                {
                    response.ResponseCode = ReturnCodesConstant.R06;
                    response.ResponseMessage = ReturnCodesConstant.R06Message;
                }
                else
                {

                    var _response = await _context.Funeral.Where(x => x.StatusId == activeStatus.StatusId).ToListAsync();

                    //foreach (var item in _response)
                    //{
                    //    var deceasedProfile = await _context.Profile.FindAsync(item.DeceasedsProfileNumber);

                    //    ActiveFuneralResponse activeFuneral = new ActiveFuneralResponse
                    //    {
                    //        FuneralId = item.FuneralId,
                    //        DeceasedsProfileNumber = item.DeceasedsProfileNumber,
                    //        AddressForFuneral = item.AddressForFuneral,
                    //        Comment = item.Comment,
                    //        DeceasedFullName = deceasedProfile.Name + " " + deceasedProfile.Surname,
                    //        DeceasedProfileStatus = (await _context.Statuses.FindAsync(deceasedProfile.Status)).StatusDescription.ToString()
                    //    };

                    //    dbResponse.Add(activeFuneral);

                    //}
                    //response = GetResponseList(response, dbResponse);
                    response = await GetActiveFuneralResponse(_response);
                }
                



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

        #region ReportsController

        public async Task<ResponseModel<ActiveFuneralResponse>> GetFuneralsPaidByProfile(int profileId, bool paid)
        {
            ResponseModel<ActiveFuneralResponse> response = InitializeActiveFuneral();
            

            try
            {

                // MSSQL Bit DataType in SQL Server USED to store boolean data
                int Sqlpaid;

                if(paid)
                {
                     Sqlpaid = 1;
                }
                else
                     Sqlpaid = 0;

                var command = $"EXEC GetFuneralsByProfile @ProfileID = {profileId}, @PaidFunerals = {Sqlpaid}";
                
                var dbResponse = await _context.Funeral.FromSqlRaw(command).ToListAsync();

                response = await GetActiveFuneralResponse(dbResponse);

            }
            catch (Exception ex)
            {

                response.ResponseCode = ReturnCodesConstant.R99;
                response.ResponseMessage = ex.Message;
            }



            return response;
        }

        

        private async Task<ResponseModel<ActiveFuneralResponse>> GetActiveFuneralResponse(List<Funeral> dbResponse)
        {
            List<ActiveFuneralResponse> _response = new List<ActiveFuneralResponse>();
            ResponseModel<ActiveFuneralResponse> response = InitializeActiveFuneral();

            foreach (var item in dbResponse)
            {
                var deceasedProfile = await _context.Profile.FindAsync(item.DeceasedsProfileNumber);

                ActiveFuneralResponse funeralRecord = new ActiveFuneralResponse
                {
                    FuneralId = item.FuneralId,
                    DeceasedsProfileNumber = item.DeceasedsProfileNumber,
                    AddressForFuneral = item.AddressForFuneral,
                    Comment = item.Comment,
                    DeceasedFullName = deceasedProfile.Name + " " + deceasedProfile.Surname,
                    DeceasedProfileStatus = (await _context.Statuses.FindAsync(deceasedProfile.Status)).StatusDescription.ToString()
                };

                _response.Add(funeralRecord);

            }
            response = GetResponseList(response, _response);

            return response;
        }


        #endregion

        #region Payments

        public async Task<bool> AddPayment(Payment payment)
        {
            var output = JsonConvert.SerializeObject(payment);
            try
            {
                

                var response = _context.Payments.Where(x => (x.Funeral == payment.Funeral && x.ProfileNumber == payment.ProfileNumber)).FirstOrDefault();
                if (response != null)
                {
                    _util.LogMessage($"Payment already exists: {output}");
                    return false;
                }
                await _context.Payments.AddAsync(payment);

                 var dbResponse = await _context.SaveChangesAsync();

                if (dbResponse > 0)
                {
                    
                    _util.LogMessage($"Payment created successfully. {output}");
                    return true;
                    
                }
                else
                {
                    _util.LogMessage($"Failed to create payment record {output}");
                    return false;

                }
                
            }
            catch (Exception ex)
            {

                _util.LogMessage($"Database error creating payment record {output} . {ex.Message}");
                return false;
            }
            
        }

        public async Task<bool> ClearPayments(string cartId)
        {

            try
            {
                var paymentsToClear =  _context.Payments.Where(x => x.CartId == cartId);

               
                if (!paymentsToClear.Any() )
                {
                    _util.LogMessage($"No payments found with cartId : {cartId}");
                    return true;
                }
                var jsonOutput = JsonConvert.SerializeObject(paymentsToClear);
                _context.Payments.RemoveRange(paymentsToClear);
                var response = await _context.SaveChangesAsync();

                if (response > 0)
                {
                    _util.LogMessage($"Payment records successfully cleared.{jsonOutput}");
                    return true;
                }
                else
                {
                    _util.LogMessage($"Zero records entities were written to the underlining database for records {jsonOutput}");
                    return false;
                }
                
            }
            catch (Exception ex)
            {
                _util.LogMessage($"Error while clearing payment records. {ex.Message}");
                return false;
            }
        }

        public async Task<List<Payment>> GetPayments(string cartId)
        {
            List<Payment> payments = new List<Payment>();
            try
            {
                payments = await _context.Payments.Where(x => x.CartId == cartId && x.TransactionId == null).ToListAsync();
                var jsonOutput = JsonConvert.SerializeObject(payments);
                if (payments.Any())
                {
                    
                    _util.LogMessage($"Records founds {jsonOutput}");
                    
                }
                else
                {
                    _util.LogMessage($"No records found for cartId: {cartId}");
                    
                }
                return payments;
            }
            catch (Exception ex)
            {

                _util.LogMessage(ex.Message);
                return payments;
            }
              
        }

        

        public async Task<bool> RemovePayment(int paymentId)
        {
            try
            {
                if (paymentId < 1 )
                {
                    throw new ArgumentException("Invalid Argument", nameof(paymentId));
                }

                var payment = _context.Payments.Find(paymentId);
                if (payment == null )
                {
                    _util.LogMessage($"Payment record {paymentId} not found.");
                    return false;
                }
                _context.Payments.Remove(payment);

                var response = await _context.SaveChangesAsync();
                if (response > 0)
                {
                    _util.LogMessage($"Payment Record {paymentId} deleted successfully.");
                    return true;
                }
                else
                {
                    _util.LogMessage($"Database failed to deleted the payment record {paymentId} ");
                    return false;
                }
            }
            catch (Exception ex)
            {

                _util.LogMessage(ex.Message);
                return false;
            }
        }

        #endregion


    }
}
