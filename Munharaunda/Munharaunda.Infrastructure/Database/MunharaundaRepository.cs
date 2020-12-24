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
        Task<Funeral> GetFuneral(int id);
        Task<IdentityTypes> GetIdentityTypes(int id);
        Task<ICollection<Funeral>> GetPaidFunerals(int profileId);
        Task<ResponseModel<ProfileResponse>> GetProfile(int id);
        Task<IEnumerable<ProfileResponse>> GetProfiles();
        Task<ProfileTypes> GetProfileType(int id);
        Task<ResponseModel<Profile>> UpdateProfile(int id, Profile profile);
        bool ProfileExists(int id);
        Task<ResponseModel<Profile>> CreateProfile(Profile profile);
        Task<ResponseModel<string>> DeleteProfile(int id);
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
                Status = profile.Status,
                Address = profile.Address,
                ActiveDate = profile.ActiveDate

            };
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
        public async Task<IdentityTypes> GetIdentityTypes(int id)
        {
            var identityTypes = await _context.IdentityTypes.FindAsync(id);

            return identityTypes;
        }

        public async Task<ProfileTypes> GetProfileType(int id)
        {
            var profileTypes = await _context.ProfileTypes.FindAsync(id);

            return profileTypes;
        }

        public async Task<Funeral> GetFuneral(int id)
        {
            var funeral = await _context.Funeral.FindAsync(id);
            return funeral;
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
                    Funerals.Add(funeral);
                }

            }

            return Funerals;
        }
    }
}
