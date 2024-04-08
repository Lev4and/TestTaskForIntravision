using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TestTaskForIntravision.Application.ConfigurationOptions;
using TestTaskForIntravision.Application.Databases.VendingMachine.EntityFramework;
using TestTaskForIntravision.Application.Extensions;

namespace TestTaskForIntravision.Application
{
    public static class VendingMachineModuleServiceCollectionExtensions
    {
        public static IServiceCollection AddVendingMachineModule(this IServiceCollection services, AppSettings settings)
        {
            services.AddVendingMachineDbPostgreSql(settings.ConnectionStrings.VendingMachineDbPostgreSql);
            services.AddVendingMachineDbEntityFrameworkRepositories();

            services.AddCqrs();

            return services;
        }

        public static void MigrateVendingMachineDb(this IHost host)
        {
            using (var serviceScope = host.Services.GetService<IServiceScopeFactory>()?.CreateScope())
            {
                serviceScope?.ServiceProvider.GetRequiredService<VendingMachineDbContext>().Database.Migrate();
            }
        }
    }
}
