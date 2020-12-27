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

        public async Task<ResponseModel<ProfileResponse>> GetProfile(int id)
        {
            var response = new ResponseModel<ProfileResponse>
            {
                ResponseData = new List<ProfileResponse>()
            };

            var profile = await _context.Profile.FindAsync(id);

            if (profile != null)
            {
                try
                {
                    var _response = await GenerateProfileDetails(profile);
                    response.ResponseData.Add(_response);
                    response.ResponseCode = ReturnCodesConstant.R00;
                    response.ResponseMessage = ReturnCodesConstant.R00Message;

                }
                catch (Exception ex)
                {

                    response.ResponseCode = ReturnCodesConstant.R99;
                    response.ResponseMessage = ex.Message;


                }

            }
            else
            {
                response.ResponseCode = ReturnCodesConstant.R06;
                response.ResponseMessage = ReturnCodesConstant.R06Message;
            }


            return response;
        }

        public async Task<IEnumerable<ProfileResponse>> GetProfiles()
        {
            List<ProfileResponse> response = new List<ProfileResponse>();

            var profiles = _context.Profile;

            foreach (var profile in profiles)
            {
                ProfileResponse profileDetails = await GenerateProfileDetails(profile);

                response.Add(profileDetails);
            }
            return response;
        }

        public async Task<ResponseModel<Profile>> UpdateProfile(int id, Profile profile)
        {

            var response = new ResponseModel<Profile>
            {

                ResponseData = new List<Profile>()
            };

            _context.Entry(profile).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                response.ResponseCode = ReturnCodesConstant.R00;
                response.ResponseMessage = ReturnCodesConstant.R00Message;
                response.ResponseData.Add(profile);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!ProfileExists(id))
                {
                    response.ResponseCode = ReturnCodesConstant.R06;
                    response.ResponseMessage = ReturnCodesConstant.R06Message;

                }
                else
                {
                    response.ResponseCode = ReturnCodesConstant.R07;
                    response.ResponseMessage = ReturnCodesConstant.R07Message;
                    response.Errors.Add(ex.Message);

                }
            }
            catch (Exception ex)
            {
                response.ResponseCode = ReturnCodesConstant.R99;
                response.ResponseMessage = ex.Message;

            }
            return response;
        }

        public async Task<ResponseModel<Profile>> CreateProfile(Profile profile)
        {

            var response = new ResponseModel<Profile>
            {
                ResponseData = new List<Profile>()
            };

            try
            {
                _context.Profile.Add(profile);
                await _context.SaveChangesAsync();

                response.ResponseCode = ReturnCodesConstant.R00;
                response.ResponseMessage = ReturnCodesConstant.R00Message;
                response.ResponseData.Add(profile);

            }
            catch (Exception ex)
            {

                response.ResponseCode = ReturnCodesConstant.R99;
                response.ResponseMessage = ex.Message;
            }

            return response;
        }

        public async Task<ResponseModel<string>> DeleteProfile(int id)
        {
            var response = new ResponseModel<string>
            {
                ResponseData = new List<string>()
            };

            try
            {
                var profile = await _context.Profile.FindAsync(id);

                if (profile == null)
                {
                    response.ResponseCode = ReturnCodesConstant.R06;
                    response.ResponseMessage = ReturnCodesConstant.R06Message;
                    return response;
                }
                _context.Profile.Remove(profile);
                await _context.SaveChangesAsync();

                response.ResponseCode = ReturnCodesConstant.R00;
                response.ResponseMessage = ReturnCodesConstant.R00Message;
                response.ResponseData.Add("Record Deleted Successfully");

            }
            catch (Exception ex)
            {

                response.ResponseCode = ReturnCodesConstant.R99;
                response.ResponseMessage = ex.Message;
            }
            return response;
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
                var _DbResponse = await _context.Funeral.ToListAsync();

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

                if (dbResponse == null)
                {
                    response.ResponseCode = ReturnCodesConstant.R06;
                    response.ResponseMessage = ReturnCodesConstant.R06Message;

                }
                else
                {
                    response.ResponseCode = ReturnCodesConstant.R00;
                    response.ResponseMessage = ReturnCodesConstant.R00Message;
                    response.ResponseData.Add(dbResponse);
                }


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

            try
            {
                _context.Entry(funeral).State = EntityState.Modified;
                var dbResponse = await _context.SaveChangesAsync();

                if (dbResponse > 0)
                {
                    response.ResponseCode = ReturnCodesConstant.R00;
                    response.ResponseMessage = ReturnCodesConstant.R00Message;
                    response.ResponseData.Add(funeral);
                }
                else
                {
                    response.ResponseCode = ReturnCodesConstant.R05;
                    response.ResponseMessage = ReturnCodesConstant.R05Message + "Funeral Not Updated";
                }

            }

            catch (DbUpdateConcurrencyException ex)
            {
                if (!IdentityTypeExists(id))
                {
                    response.ResponseCode = ReturnCodesConstant.R06;
                    response.ResponseMessage = ReturnCodesConstant.R06Message;
                }
                else
                {
                    response.ResponseCode = ReturnCodesConstant.R99;
                    response.ResponseMessage = ex.Message;
                }
            }
            catch (Exception ex)
            {

                response.ResponseCode = ReturnCodesConstant.R99;
                response.ResponseMessage = ex.Message;
            }

            return response;
        }

        public async Task<ResponseModel<Funeral>> CreateFuneral(Funeral funeral)
        {
            ResponseModel<Funeral> response = InitializeFuneral();

            try
            {
                var test = _context.Funeral.Add(funeral);
                var dbResponse = await _context.SaveChangesAsync();

                if (dbResponse > 0)
                {
                    response.ResponseCode = ReturnCodesConstant.R00;
                    response.ResponseMessage = ReturnCodesConstant.R00Message;
                    response.ResponseData.Add(funeral);
                }
                else
                {
                    response.ResponseCode = ReturnCodesConstant.R05;
                    response.ResponseMessage = ReturnCodesConstant.R05Message + " Record not created try again..";

                }

            }
            catch (Exception ex)
            {

                response.ResponseCode = ReturnCodesConstant.R99;
                response.ResponseMessage = ex.Message;
            }



            return response;
        }

        public async Task<ResponseModel<Funeral>> DeleteFuneral(int id)
        {
            ResponseModel<Funeral> response = InitializeFuneral();

            try
            {
                var dbResponse = await GetFuneral(id);

                if (dbResponse.ResponseCode == ReturnCodesConstant.R00)
                {
                    _context.Funeral.Remove(dbResponse.ResponseData[0]);
                    var _response = await _context.SaveChangesAsync();

                    if (_response > 0)
                    {
                        response.ResponseCode = ReturnCodesConstant.R00;
                        response.ResponseMessage = ReturnCodesConstant.R00Message;
                    }
                    else
                    {
                        response.ResponseCode = ReturnCodesConstant.R05;
                        response.ResponseMessage = ReturnCodesConstant.R05Message + " Record not deleted";
                    }

                }

            }
            catch (Exception ex)
            {

                response.ResponseCode = ReturnCodesConstant.R99;
                response.ResponseMessage = ex.Message;
            }
            return response;
        }

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


        public bool IdentityTypeExists(int id)
        {
            return _context.IdentityTypes.Any(e => e.IdentityTypeId == id);
        }



        #endregion

        #region IdentityTypesController

        public async Task<ResponseModel<IdentityTypes>> GetIdentityTypes()
        {
            ResponseModel<IdentityTypes> response = InitializeIdType();
            try
            {
                var dbResponse = await _context.IdentityTypes.ToListAsync();

                if (dbResponse.Count > 0)
                {
                    response.ResponseCode = ReturnCodesConstant.R00;
                    response.ResponseMessage = ReturnCodesConstant.R00Message;

                    foreach (var item in dbResponse)
                    {
                        response.ResponseData.Add(item);
                    }

                }
                else
                {
                    response.ResponseCode = ReturnCodesConstant.R06;
                    response.ResponseMessage = ReturnCodesConstant.R06Message;
                }
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

                if (dbResponse == null)
                {
                    response.ResponseCode = ReturnCodesConstant.R06;
                    response.ResponseMessage = ReturnCodesConstant.R06Message;
                }
                else
                {
                    response.ResponseCode = ReturnCodesConstant.R00;
                    response.ResponseMessage = ReturnCodesConstant.R00Message;
                    response.ResponseData.Add(dbResponse);
                }
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

            try
            {
                var dbResponse = await _context.SaveChangesAsync();

                if (dbResponse > 0)
                {
                    response.ResponseCode = ReturnCodesConstant.R00;
                    response.ResponseMessage = ReturnCodesConstant.R00Message;
                    response.ResponseData.Add(identityType);
                }
                else
                {
                    response.ResponseCode = ReturnCodesConstant.R05;
                    response.ResponseMessage = ReturnCodesConstant.R05Message + "Update failed";
                }


            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!IdentityTypesExists(id))
                {
                    response.ResponseCode = ReturnCodesConstant.R06;
                    response.ResponseMessage = ReturnCodesConstant.R06Message;
                }
                else
                {
                    response.ResponseCode = ReturnCodesConstant.R99;
                    response.ResponseMessage = ex.Message;
                }
            }
            catch (Exception ex)
            {
                response.ResponseCode = ReturnCodesConstant.R99;
                response.ResponseMessage = ex.Message;
            }
            return response;
        }

        public async Task<ResponseModel<IdentityTypes>> CreateIdentityType(IdentityTypes identityType)
        {
            ResponseModel<IdentityTypes> response = InitializeIdType();

            try
            {
                _context.IdentityTypes.Add(identityType);
                var dbResponse = await _context.SaveChangesAsync();

                if (dbResponse > 0)
                {
                    response.ResponseCode = ReturnCodesConstant.R00;
                    response.ResponseMessage = ReturnCodesConstant.R00Message;
                    response.ResponseData.Add(identityType);
                }
                else
                {
                    response.ResponseCode = ReturnCodesConstant.R05;
                    response.ResponseMessage = ReturnCodesConstant.R05Message + "Record Not Created";
                }

            }
            catch (Exception ex)
            {

                response.ResponseCode = ReturnCodesConstant.R99;
                response.ResponseMessage = ex.Message;
            }

            return response;
        }

        public async Task<ResponseModel<IdentityTypes>> DeleteIdentityType(int id)
        {
            ResponseModel<IdentityTypes> response = InitializeIdType();

            try
            {
                if (IdentityTypesExists(id))
                {
                    var dbResponse = await _context.IdentityTypes.FindAsync(id);
                    _context.IdentityTypes.Remove(dbResponse);
                    var _response = await _context.SaveChangesAsync();

                    if (_response > 0)
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
                else
                {
                    response.ResponseCode = ReturnCodesConstant.R06;
                    response.ResponseMessage = ReturnCodesConstant.R06Message;
                }
            }
            catch (Exception ex)
            {

                response.ResponseCode = ReturnCodesConstant.R99;
                response.ResponseMessage = ex.Message;
            }



            return response;
        }
        public bool IdentityTypesExists(int id)
        {
            return _context.IdentityTypes.Any(e => e.IdentityTypeId == id);
        }

        public bool FuneralExists(int id)
        {
            return _context.Funeral.Any(e => e.FuneralId == id); ;
        }
        #endregion

        #region ProfileTypeController

        public async Task<ResponseModel<ProfileTypes>> GetProfileTypes()
        {
            ResponseModel<ProfileTypes> response = InitializeProfileType();

            try
            {
                var dbResponse = await _context.ProfileTypes.ToListAsync();

                if (dbResponse.Count > 0)
                {
                    response.ResponseCode = ReturnCodesConstant.R00;
                    response.ResponseMessage = ReturnCodesConstant.R00Message;
                    response.ResponseData = dbResponse;
                }
                else
                {
                    response.ResponseCode = ReturnCodesConstant.R06;
                    response.ResponseMessage = ReturnCodesConstant.R06Message;
                }
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
                var profileTypes = await _context.ProfileTypes.FindAsync(id);

                if (profileTypes == null)
                {

                    response.ResponseCode = ReturnCodesConstant.R06;
                    response.ResponseMessage = ReturnCodesConstant.R06Message;
                }
                else
                {
                    response.ResponseCode = ReturnCodesConstant.R00;
                    response.ResponseMessage = ReturnCodesConstant.R00Message;
                    response.ResponseData.Add(profileTypes);
                }
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

            try
            {
                var dbResponse = await _context.SaveChangesAsync();
                if (dbResponse > 0)
                {
                    response.ResponseCode = ReturnCodesConstant.R00;
                    response.ResponseMessage = ReturnCodesConstant.R00Message;
                    response.ResponseData.Add(profileTypes);
                }
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!ProfileTypesExists(id))
                {
                    response.ResponseCode = ReturnCodesConstant.R06;
                    response.ResponseMessage = ReturnCodesConstant.R06Message;

                }
                else
                {
                    response.ResponseCode = ReturnCodesConstant.R99;
                    response.ResponseMessage = ex.Message;
                }
            }
            catch (Exception ex)
            {
                response.ResponseCode = ReturnCodesConstant.R99;
                response.ResponseMessage = ex.Message;
            }
            return response;
        }

        public async Task<ResponseModel<ProfileTypes>> CreateProfileType(ProfileTypes profileTypes)
        {
            ResponseModel<ProfileTypes> response = InitializeProfileType();

            try
            {
                _context.ProfileTypes.Add(profileTypes);
                var dbResponse = await _context.SaveChangesAsync();

                if (dbResponse > 0)
                {
                    response.ResponseCode = ReturnCodesConstant.R00;
                    response.ResponseMessage = ReturnCodesConstant.R00Message;
                    response.ResponseData.Add(profileTypes);
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

        public  async Task<ResponseModel<ProfileTypes>> DeleteProfileType(int id)
        {
            ResponseModel<ProfileTypes> response = InitializeProfileType();

            try
            {
                if (ProfileTypesExists(id))
                {
                    var profileTypes = await _context.ProfileTypes.FindAsync(id);

                    _context.ProfileTypes.Remove(profileTypes);

                    var dbResponse = await _context.SaveChangesAsync();

                    if (dbResponse > 0)
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
                else
                {
                    response.ResponseCode = ReturnCodesConstant.R06;
                    response.ResponseMessage = ReturnCodesConstant.R06Message;
                }
            }
            catch (Exception ex)
            {

                response.ResponseCode = ReturnCodesConstant.R99;
                response.ResponseMessage = ex.Message;
            }

            
            return response;
        }
        public bool ProfileTypesExists(int id)
        {
            return _context.ProfileTypes.Any(e => e.ProfileTypeId == id);
        }
        #endregion

        #region StatusController
        
        public async Task<ResponseModel<Statuses>> GetStatuses()
        {
            ResponseModel<Statuses> response = InitializeStatuses();

            try
            {
                var dbResponse = await _context.Statuses.ToListAsync();

                if (dbResponse.Count > 0)
                {
                    response.ResponseCode = ReturnCodesConstant.R00;
                    response.ResponseMessage = ReturnCodesConstant.R00Message;
                    response.ResponseData = dbResponse;
                }
                else
                {
                    response.ResponseCode = ReturnCodesConstant.R06;
                    response.ResponseMessage = ReturnCodesConstant.R06Message;
                }
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
                var statuses = await _context.Statuses.FindAsync(id);

                if (statuses == null)
                {
                    response.ResponseCode = ReturnCodesConstant.R06;
                    response.ResponseMessage = ReturnCodesConstant.R06Message;
                    
                }
                else
                {
                    response.ResponseCode = ReturnCodesConstant.R00;
                    response.ResponseMessage = ReturnCodesConstant.R00Message;
                    response.ResponseData.Add(statuses);
                }
            }
            catch (Exception ex )
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

            try
            {
                var dbResponse = await _context.SaveChangesAsync();

                if (dbResponse > 0)
                {
                    response.ResponseCode = ReturnCodesConstant.R00;
                    response.ResponseMessage = ReturnCodesConstant.R00Message;
                    response.ResponseData.Add(statuses);
                }
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!StatusesExists(id))
                {
                    response.ResponseCode = ReturnCodesConstant.R06;
                    response.ResponseMessage = ReturnCodesConstant.R06Message;
                }
                else
                {
                    response.ResponseCode = ReturnCodesConstant.R05;
                    response.ResponseMessage = ex.Message;
                }
            }
            catch (Exception ex)
            {
                response.ResponseCode = ReturnCodesConstant.R99;
                response.ResponseMessage = ex.Message;
            }

            return response;

        }

        public async Task<ResponseModel<Statuses>> CreateStatus(Statuses statuses)
        {
            ResponseModel<Statuses> response = InitializeStatuses();

            try
            {
                _context.Statuses.Add(statuses);
                var dbResponse = await _context.SaveChangesAsync();

                if (dbResponse > 0)
                {
                    response.ResponseCode = ReturnCodesConstant.R00;
                    response.ResponseMessage = ReturnCodesConstant.R00Message;
                    response.ResponseData.Add(statuses);
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

        public async Task<ResponseModel<Statuses>> DeleteStatus(int id)
        {
            ResponseModel<Statuses> response = InitializeStatuses();

            try
            {
                var statuses = await _context.Statuses.FindAsync(id);
                if (statuses == null)
                {
                    response.ResponseCode = ReturnCodesConstant.R06;
                    response.ResponseMessage = ReturnCodesConstant.R06Message;
                    
                }
                else
                {

                    _context.Statuses.Remove(statuses);
                    var dbResponse = await _context.SaveChangesAsync();

                    if (dbResponse > 0)
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



            }
            catch (Exception ex)
            {

                response.ResponseCode = ReturnCodesConstant.R99;
                response.ResponseMessage = ex.Message;
            }
            return response;
        }
        private static ResponseModel<Statuses> InitializeStatuses()
        {
            var response = new ResponseModel<Statuses>();
            response.ResponseData = new List<Statuses>();
            return response;
        }

        private bool StatusesExists(int id)
        {
            return _context.Statuses.Any(e => e.StatusId == id);
        }
        #endregion


    }
}
