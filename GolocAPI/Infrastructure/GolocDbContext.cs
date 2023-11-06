using GolocAPI.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Reflection.Emit;

namespace Infrastructure
{
    public class GolocDbContext : IdentityDbContext<User>
    {
        private readonly ILogger<GolocDbContext> _logger;
        public DbSet<User> Users { get; set; }
        public GolocDbContext(DbContextOptions<GolocDbContext> options,
        ILogger<GolocDbContext> logger)
         : base(options)
        {
            _logger = logger;
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<IdentityRole>()
                .HasData(
                    new IdentityRole { Name = "Member", NormalizedName = "MEMBER" },
                    new IdentityRole { Name = "Admin", NormalizedName = "ADMIN" }
                );
            base.OnModelCreating(builder);
        }
    }
}
