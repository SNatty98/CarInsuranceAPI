using InsuranceAPI.Models;
using InsuranceAPI.Data.Enums;
using Microsoft.EntityFrameworkCore;

namespace InsuranceAPI.Data;

public class InsuranceDbContext : DbContext
{

    public InsuranceDbContext(DbContextOptions<InsuranceDbContext> options)
        : base(options)
    {
    }

    public DbSet<Claim> Claims { get; set; }
    public DbSet<Driver> Driver { get; set; }
    public DbSet<Policy> Policies { get; set; }
    public DbSet<PolicyDriver> PolicyDrivers { get; set; }
    public DbSet<Quote> Quotes { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Vehicle> Vehicles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Claim>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Description).IsRequired().HasMaxLength(1000);
            entity.Property(e => e.ClaimAmount).HasPrecision(18, 2);
            entity.Property(e => e.Status).HasConversion<string>();

            entity.HasOne(e => e.Policy)
            .WithMany(u => u.Claims)
            .HasForeignKey(e => e.PolicyId)
            .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.ReviewedByAgent)
            .WithMany()
            .HasForeignKey(e => e.ReviewedByAgentId)
            .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.ReviewedByAdmin)
            .WithMany()
            .HasForeignKey(e => e.ReviewedByAdminId)
            .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<Driver>(entity =>
        {
            entity.HasKey(entity => entity.Id);
            entity.Property(e => e.FirstName).IsRequired().HasMaxLength(100);
            entity.Property(e => e.LastName).IsRequired().HasMaxLength(100);
            entity.Property(e => e.LicenceNumber).IsRequired().HasMaxLength(50);

            entity.HasOne(e => e.User)
            .WithMany(u => u.Drivers)
            .HasForeignKey(e => e.UserId)
            .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Policy>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.PolicyNumber).IsRequired().HasMaxLength(30);
            entity.Property(e => e.Premium).HasPrecision(18, 2);
            entity.HasIndex(e => e.PolicyNumber).IsUnique();
            entity.Property(e => e.Status).HasConversion<string>();

            entity.HasOne(e => e.User)
            .WithMany(u => u.Policies)
            .HasForeignKey(e => e.UserId)
            .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.Quote)
            .WithOne(q => q.Policy)
            .HasForeignKey<Policy>(p => p.QuoteId)
            .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.Vehicle)
            .WithMany(v => v.Policies)
            .HasForeignKey(e => e.VehicleId)
            .OnDelete(DeleteBehavior.Restrict);

        });

        modelBuilder.Entity<PolicyDriver>(entity =>
        {
            entity.HasKey(pd => new { pd.PolicyId, pd.DriverId });

            entity.HasOne(pd => pd.Policy)
                .WithMany(p => p.PolicyDrivers)
                .HasForeignKey(pd => pd.PolicyId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(pd => pd.Driver)
            .WithMany(d => d.PolicyDrivers)
            .HasForeignKey(pd => pd.DriverId)
            .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Email).IsRequired().HasMaxLength(50);
            entity.HasIndex(e => e.Email).IsUnique();
            entity.Property(e => e.PasswordHash).IsRequired();
            entity.Property(e => e.Role).HasConversion<string>();
        });

        modelBuilder.Entity<Vehicle>(entity =>
        {
            entity.HasKey(entity => entity.Id);
            entity.Property(e => e.Make).IsRequired().HasMaxLength(40);
            entity.Property(e => e.Model).IsRequired().HasMaxLength(60);
            entity.Property(e => e.RegistrationNumber).IsRequired().HasMaxLength(20);
            entity.HasIndex(e => e.RegistrationNumber).IsUnique();
            entity.Property(e => e.EngineSize).HasPrecision(3, 1);
            entity.Property(e => e.Value).HasPrecision(18, 2);

            entity.HasOne(e => e.User)
            .WithMany(u => u.Vehicles)
            .HasForeignKey(e => e.UserId)
            .OnDelete(DeleteBehavior.Restrict);
        });

        SeedData(modelBuilder);
    }

    private void SeedData(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasData(new User
        {
            Id = 1,
            Email = "admin@insuranceapi.com",
            PasswordHash = BCrypt.Net.BCrypt.HashPassword("Admin123!"),
            Role = UserRole.Admin,
            CreatedAt = DateTime.UtcNow
        });
    }
}
