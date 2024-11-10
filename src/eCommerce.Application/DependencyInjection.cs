using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace eCommerce.Application;
public static class DependencyInjection
{
    public static void AddDependencyInjectionApplication(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));
    }
}
