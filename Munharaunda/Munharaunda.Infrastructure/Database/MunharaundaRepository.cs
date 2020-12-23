using Microsoft.EntityFrameworkCore;
using Munharaunda.Domain.Models;
using Munharaunda.Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Munharaunda.Infrastructure.Database
{
    public class MunharaundaRepository
    {
        private readonly MunharaundaDbContext _context;

        public MunharaundaRepository(MunharaundaDbContext context)
        {
            _context = context;
        }


        public async Task<ProfileResponse> GenerateProfileResponse(Profile profile) =>
            new ProfileResponse
            {
                ProfileNumber = profile.ProfileNumber,
                ProfileType = await GetProfileType(profile.ProfileTypeId),
                FullName = profile.Name + " " + profile.Surname,
                IdentityType = await GetIdentityTypes(profile.IdentityTypeId),
                IdentityNumber = profile.IdentityNumber,
                DateOfBirth = profile.DateOfBirth,
                PhoneNumber = profile.PhoneNumber,
                PaidFuneral = await GetPaidFunerals(profile.ProfileNumber),
                Status = profile.Status

            };

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
            var transactions = await  _context.Transactions.Where(f => f.Contribution == true && f.CreatedBy == profileId ).ToListAsync();

            foreach (var item in transactions)
            {
                var funeral = await GetFuneral(item.FuneralId);

                if (funeral != null )
                {
                    Funerals.Add(funeral);
                }
                
            }

            return Funerals;
        }
    } 
}
