using BlazorUserProfileApp.Shared;
using Microsoft.EntityFrameworkCore;

namespace BlazorUserProfileApp.Server.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Profile> Profiles { get; set; }
    }
}

