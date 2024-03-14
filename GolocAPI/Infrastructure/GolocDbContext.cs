using GolocAPI.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
namespace Infrastructure;
public class GolocDbContext : IdentityDbContext<User>
{
    private readonly ILogger<GolocDbContext> _logger;
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductCategory> ProductCategories { get; set; }
    public DbSet<Rent> Rents { get; set; }
    public DbSet<ChatMessage> ChatMessages { get; set; }
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
        builder.Entity<Rent>()
    .HasOne(c => c.Product)
    .WithMany(product => product.Rents)
    .OnDelete(DeleteBehavior.NoAction);

        builder.Entity<ChatMessage>()
    .HasOne(c => c.Sender)
    .WithMany(product => product.ChatMessgages)
    .OnDelete(DeleteBehavior.NoAction);
        base.OnModelCreating(builder);
    }
}
