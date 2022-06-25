using SkillTracker.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillTracker.Business
{
    public interface IProfile
    {
        Task<IEnumerable<Profiles>> GetProfilesAsync();
        Task<Profiles> GetProfileAsync(string id);
        Task CreateProfileAsync(Profiles profile);
        Task<bool> UpdateProfileAsync(Profiles profile);
        Task<IEnumerable<Profiles>> GetProfilesAsync(string criteria, string criteriaValue);


    }
}
