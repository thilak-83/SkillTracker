using Microsoft.AspNetCore.Mvc;
using SkillTracker.Business;
using SkillTracker.Entity;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace SkillTracker.API.Controllers
{
    [Route("skill-tracker/api/v1/[controller]")]
    [ApiController]
    public class EngineerController : ControllerBase
    {
        private readonly IProfile _profile;
        public EngineerController(IProfile profile)
        {
            _profile = profile;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Profiles>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Profiles>>> GetProfiles()
        {
            var profiles = await _profile.GetProfilesAsync();
            return Ok(profiles);
        }

        [HttpPost("add-profile")]
        [ProducesResponseType(typeof(Profiles), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Profiles>> CreateProfile([FromBody] Profiles profiles)
        {
            await _profile.CreateProfileAsync(profiles);
            return Ok();

        }

        [HttpPut("update-profile/{id}")]
        [ProducesResponseType(typeof(Profiles), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> UpdateProfile([FromBody] Profiles profiles)
        {
            return Ok(await _profile.UpdateProfileAsync(profiles));

        }

        [HttpGet("admin/{criteria/criteriaValue")]
        [ProducesResponseType(typeof(IEnumerable<Profiles>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Profiles>>> GetProfiles(string criteria, string criteriaValue)
        {
            var profiles = await _profile.GetProfilesAsync(criteria, criteriaValue);
            return Ok(profiles);
        }
    }
}
