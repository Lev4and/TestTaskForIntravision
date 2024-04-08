using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TestTaskForIntravision.Application.Databases.VendingMachine.EntityFramework;
using TestTaskForIntravision.Domain.Infrastructure.Databases;
using TestTaskForIntravision.Domain.Repositories;
using TestTaskForIntravision.Infrastructure.Databases.EntityFramework.Repositories;
using TestTaskForIntravision.Application.Databases.VendingMachine.EntityFramework.Repositories;
using FluentValidation;
using MediatR;
using System.Reflection;
using TestTaskForIntravision.Application.Pipelines;
using TestTaskForIntravision.Domain.Entities;

namespace TestTaskForIntravision.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddVendingMachineDbPostgreSql(this IServiceCollection services, 
            string connectionString)
        {
            services.AddDbContext<VendingMachineDbContext>((options) =>
            {
                options.UseNpgsql(connectionString).UseSnakeCaseNamingConvention();
            });

            services.AddScoped<IUnitOfWork>(serviceProvider =>
                serviceProvider.GetRequiredService<VendingMachineDbContext>());

            return services;
        }

        public static IServiceCollection AddVendingMachineDbEntityFrameworkRepositories(this IServiceCollection services)
        {
            services.AddTransient<IBeverageRepository, BeverageRepository>();
            services.AddTransient<ICoinRepository, CoinRepository>();
            services.AddTransient<IStorageBeverageRepository, StorageBeverageRepository>();
            services.AddTransient<IStorageCoinRepository, StorageCoinRepository>();

            services.AddTransient<IRepository, VendingMachineDbEntityFrameworkRepository>();

            return services;
        }

        public static IServiceCollection AddCqrs(this IServiceCollection services)
        {
            services.AddMediatR(config => config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationPipeline<,>));

            return services;
        }
    }
}
