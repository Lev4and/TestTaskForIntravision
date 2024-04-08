using Asp.Versioning;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.OpenApi.Models;
using Serilog;
using System.Text.Json.Serialization;
using TestTaskForIntravision.Application;
using TestTaskForIntravision.Application.ConfigurationOptions;
using TestTaskForIntravision.Application.Web.Middlewares;
using TestTaskForIntravision.Infrastructure.Web.Middlewares;
using TestTaskForIntravision.WebApi.OpenApi;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context, loggerConfig) =>
    loggerConfig.ReadFrom.Configuration(context.Configuration));

var appSettings = new AppSettings();

builder.Configuration.Bind(appSettings);

builder.Services.AddVendingMachineModule(appSettings);

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder => builder.WithOrigins("http://localhost")
        .AllowAnyMethod().AllowAnyHeader().AllowCredentials());
});

builder.Services.AddControllers().AddJsonOptions(options =>
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    options.AddServer(new OpenApiServer()
    {
        Url = "http://localhost/"
    });
});
builder.Services.AddSwaggerGenNewtonsoftSupport();

builder.Services.AddApiVersioning(options =>
{
    options.DefaultApiVersion = new ApiVersion(1);
    options.ApiVersionReader = new UrlSegmentApiVersionReader();
})
.AddApiExplorer(options =>
{
    options.GroupNameFormat = "'v'V";
    options.SubstituteApiVersionInUrl = true;
});

builder.Services.ConfigureOptions<ConfigureSwaggerGenOptions>();

builder.Services.AddHttpContextAccessor();

builder.Services.Configure<ForwardedHeadersOptions>(options =>
{
    options.ForwardedHeaders = ForwardedHeaders.XForwardedFor
        | ForwardedHeaders.XForwardedProto;
});

var app = builder.Build();

app.MigrateVendingMachineDb();

app.UseSwagger();
app.UseSwaggerUI(options =>
{
    var descriptions = app.DescribeApiVersions();

    foreach (var description in descriptions)
    {
        var url = $"/api/swagger/{description.GroupName}/swagger.json";
        var name = description.GroupName.ToUpperInvariant();

        options.SwaggerEndpoint(url, name);
    }
});

app.UseSerilogRequestLogging();

app.UseForwardedHeaders();

app.UseCors();

app.UseRouting();
app.UseAuthorization();
app.MapControllers();

app.UseMiddleware<AutoWrapJsonResponseMiddleware>();
app.UseMiddleware<GlobalExceptionHandlerMiddleware>();

app.Run();
