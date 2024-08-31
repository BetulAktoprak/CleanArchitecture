using CleanArchitecture.Domain.Abstractions;
using CleanArchitecture.Domain.Entities;
using GenericRepository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Persistance.Context;
public sealed class AppDbContext : IdentityDbContext<AppUser, Role, string>, IUnitOfWork
{
    public AppDbContext(DbContextOptions options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AssemblyReference).Assembly);

        modelBuilder.Ignore<IdentityUserLogin<string>>();
        modelBuilder.Ignore<IdentityUserRole<string>>();
        modelBuilder.Ignore<IdentityUserClaim<string>>();
        modelBuilder.Ignore<IdentityUserToken<string>>();
        modelBuilder.Ignore<IdentityRoleClaim<string>>();
        modelBuilder.Ignore<IdentityRole<string>>();
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var entries = ChangeTracker.Entries<Entity>();
        foreach (var entry in entries)
        {
            if (entry.State == EntityState.Added)
                entry.Property(p => p.CreatedDate)
                    .CurrentValue = DateTime.Now;

            if (entry.State == EntityState.Modified)
                entry.Property(p => p.UpdatedDate)
                    .CurrentValue = DateTime.Now;
        }

        return base.SaveChangesAsync(cancellationToken);
    }
}
