using SkillTracker.Data;
using SkillTracker.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SkillTracker.Business
{
    public class Profile : IProfile
    {
        private readonly IProfileRepository _iprofileRepository;
        public Profile(IProfileRepository profileRepository)
        {
            _iprofileRepository = profileRepository;
        }
        public async Task<IEnumerable<Profiles>> GetProfilesAsync()
        {
            return await _iprofileRepository.Get();
        }

        public async Task<Profiles> GetProfileAsync(string id)
        {
            return await _iprofileRepository.Get(id);
        }

        public async Task CreateProfileAsync(Profiles profile)
        {
            if (profile == null)
                throw new ArgumentNullException(nameof(profile));

            await _iprofileRepository.Create(profile);
        }

        public async Task<bool> UpdateProfileAsync(Profiles profile)
        {
            return await _iprofileRepository.Update(profile, profile.Id.ToString());
        }

        public Task<IEnumerable<Profiles>> GetProfilesAsync(string criteria, string criteriaValue)
        {
            throw new NotImplementedException();
        }
    }
}
 