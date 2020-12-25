using Microsoft.EntityFrameworkCore;
using Munharaunda.Core.Constants;
using Munharaunda.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Munharaunda.Infrastructure.Database
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
    }

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
                                       
            ResponseModel<Funeral> response = Initialize();

            try
            {
                var _DbResponse = await _context.Funeral.ToListAsync();

                if (_DbResponse.Count == 0 )
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
            ResponseModel<Funeral> response = Initialize();
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
            ResponseModel<Funeral> response = Initialize();

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
                if (!FuneralExists(id))
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
            ResponseModel<Funeral> response = Initialize();

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
            ResponseModel<Funeral> response = Initialize();

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

        private static ResponseModel<Funeral> Initialize()
        {
            var response = new ResponseModel<Funeral>();
            response.ResponseData = new List<Funeral>();
            return response;
        }

        public bool FuneralExists(int id)
        {
            return _context.Funeral.Any(e => e.FuneralId == id);
        }



        #endregion
    }
}
