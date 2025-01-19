using eCommerce.Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eCommerce.Infra.DataAccess.EntitiesConfiguration;
public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.Id);
        builder.HasAlternateKey(u => u.Email);
        builder.Property(u => u.Name).HasMaxLength(128).IsRequired();
        builder.Property(u => u.Email).HasMaxLength(128).IsRequired();
        builder.Property(u => u.CPF).HasMaxLength(15);
        builder.Property(u => u.RG).HasMaxLength(10);
        /*builder.HasData(
            new User(1, "admin", "admin@localhost"));*/
    }
}
