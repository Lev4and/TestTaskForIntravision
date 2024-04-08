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
            //foreach (var repositoryInterface in typeof(ServiceCollectionExtensions).Assembly.GetTypes()
            //    .Where(type => type.IsInterface && type.HasInterface(typeof(IRepository<>))))
            //{
            //    foreach (var repository in typeof(ServiceCollectionExtensions).Assembly.GetTypes()
            //        .Where(type => type.IsClass && type.HasInterface(repositoryInterface)
            //            && type.HasInterface(typeof(IEntityFrameworkRepository<>))))
            //    {
            //        services.AddTransient(repositoryInterface, repository);
            //    }
            //}

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
