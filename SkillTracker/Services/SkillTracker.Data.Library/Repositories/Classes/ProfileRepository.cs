using SkillTracker.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillTracker.Data
{
    public class ProfileRepository : BaseRepository<Profiles>, IProfileRepository
    {
        public ProfileRepository(ISkillContext context) : base(context)
        {

        }
    }
}
