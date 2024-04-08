using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System.Reflection;

namespace TestTaskForIntravision.Application.Databases.VendingMachine.EntityFramework
{
    public class VendingMachineDbContextFactory : IDesignTimeDbContextFactory<VendingMachineDbContext>
    {
        public VendingMachineDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder();

            builder
                .UseNpgsql("", builder => builder.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName))
                .UseSnakeCaseNamingConvention();

            return new VendingMachineDbContext(builder.Options);
        }
    }
}
