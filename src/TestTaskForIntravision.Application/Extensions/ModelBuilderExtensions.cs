using Microsoft.EntityFrameworkCore;

namespace TestTaskForIntravision.Application.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static ModelBuilder AddDefaultData(this ModelBuilder modelBuilder)
        {
            return modelBuilder;
        }
    }
}
