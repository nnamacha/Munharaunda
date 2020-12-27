using Munharaunda.Domain.Models;
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

    }
}
