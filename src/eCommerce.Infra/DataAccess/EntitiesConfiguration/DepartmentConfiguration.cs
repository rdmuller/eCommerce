using eCommerce.Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eCommerce.Infra.DataAccess.EntitiesConfiguration;
public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
{
    public void Configure(EntityTypeBuilder<Department> builder)
    {
        builder.HasKey(d => d.Id);
        builder.HasIndex(d => d.Name).HasDatabaseName("IDepartment1");

        builder.Property(d => d.Name).IsRequired().HasMaxLength(128);

        builder.HasData(
            new Department(1, "Moda"),
            new Department(2, "Informática"),
            new Department(3, "Eletrodomésticos"),
            new Department(4, "Automóveis")
        );
    }
}
