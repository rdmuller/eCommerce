using eCommerce.Domain.Repositories;
using eCommerce.Domain.Repositories.Departments;
using eCommerce.Domain.Repositories.Users;
using eCommerce.Infra.DataAccess;
using eCommerce.Infra.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace eCommerce.Infra.IoC;
public static class DependencyInectionExtension
{
    public static void AddInfra(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<ISaveChangesInterceptor, AuditableEntityInterceptor>();
        services.AddSingleton(TimeProvider.System);

        AddDbContext(services, configuration);
        
        AddRepositories(services);
    }

    private static void AddRepositories(IServiceCollection services)
    {
        services.AddScoped<IUserReadOnlyRepository, UserRepository>();
        services.AddScoped<IUserWriteOnlyRepository, UserRepository>();
        services.AddScoped<IDepartmentReadOnlyRepository, DepartmentRepository>();
        services.AddScoped<IDepartmentWriteOnlyRepository, DepartmentRepository>();

        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }

    private static void AddDbContext(IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        services.AddDbContext<eCommerceDbContext>((sp, options) =>
        {
            options.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());
            options.UseSqlServer(connectionString, b => b.MigrationsAssembly(typeof(eCommerceDbContext).Assembly.FullName));
        });
    }
}
