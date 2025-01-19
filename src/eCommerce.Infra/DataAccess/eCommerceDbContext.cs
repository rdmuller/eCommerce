using eCommerce.Domain.Entites;
using eCommerce.Infra.DataAccess.EntitiesConfiguration;
using eCommerce.Infra.Security;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.Infra.DataAccess;
public class eCommerceDbContext : IdentityDbContext<ApplicationUser>
{
    public eCommerceDbContext(DbContextOptions<eCommerceDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<DeliveryAddress> DeliveryAddresses { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(eCommerceDbContext).Assembly);
        //modelBuilder.ApplyConfiguration(new UserConfiguration());
        //modelBuilder.ApplyConfiguration(new ContactConfiguration());
        base.OnModelCreating(modelBuilder);
    }
}