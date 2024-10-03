using BlazorUserProfileApp.Server.Data;
using BlazorUserProfileApp.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlazorUserProfileApp.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfilesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProfilesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Profile>>> GetProfiles()
        {
            return await _context.Profiles.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Profile>> GetProfile(int id)
        {
            var profile = await _context.Profiles.FindAsync(id);

            if (profile == null)
            {
                return NotFound();
            }

            return profile;
        }

        [HttpPost]
        public async Task<ActionResult<Profile>> CreateOrUpdateProfile([FromBody] Profile profile)
        {
            if (profile == null)
            {
                return BadRequest("Profile data is null.");
            }

            // Check if the profile with the given ID exists
            var existingProfile = await _context.Profiles.FindAsync(profile.Id);

            if (existingProfile != null)
            {
                // Update the existing profile
                existingProfile.FirstName = profile.FirstName;
                existingProfile.LastName = profile.LastName;
                existingProfile.PhoneNumber = profile.PhoneNumber;
                existingProfile.Image = profile.Image;

                _context.Entry(existingProfile).State = EntityState.Modified;
            }
            else
            {
                // Create a new profile
                _context.Profiles.Add(profile);
            }

            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProfile), new { id = profile.Id }, profile);
        }
    }
}