using Asp.Versioning.ApiExplorer;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace TestTaskForIntravision.WebApi.OpenApi
{
    public class ConfigureSwaggerGenOptions : IConfigureNamedOptions<SwaggerGenOptions>
    {
        private readonly IApiVersionDescriptionProvider _provider;

        public ConfigureSwaggerGenOptions(IApiVersionDescriptionProvider provider)
        {
            _provider = provider;
        }

        public void Configure(string? name, SwaggerGenOptions options)
        {
            foreach (var description in _provider.ApiVersionDescriptions)
            {
                var openApiInfo = new OpenApiInfo()
                {
                    Title = $"VendingMachine.Api v{description.ApiVersion}",
                    Version = description.ApiVersion.ToString()
                };

                options.SwaggerDoc(description.GroupName, openApiInfo);
            }
        }

        public void Configure(SwaggerGenOptions options)
        {
            throw new NotImplementedException();
        }
    }
}
