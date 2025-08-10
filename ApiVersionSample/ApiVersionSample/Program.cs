
using Asp.Versioning;
using Microsoft.OpenApi.Models;

namespace ApiVersionSample;

public class Program
{
    private static readonly string Title = "Sample API";

    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1",
                Title = $"{Title} V1",
            });

            c.SwaggerDoc("v2", new OpenApiInfo
            {
                Version = "v2",
                Title = $"{Title} V2",
            });

            c.SwaggerDoc("v3", new OpenApiInfo
            {
                Version = "v3",
                Title = $"{Title} V3",
            });

            c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
        });

        builder.Services.AddApiVersioning(options =>
            {
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.ReportApiVersions = true;
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.ApiVersionReader = ApiVersionReader.Combine(
                    new QueryStringApiVersionReader(),
                    new UrlSegmentApiVersionReader(),
                    new MediaTypeApiVersionReader("version"),
                    new HeaderApiVersionReader("X-Api-Version"));
                options.ApiVersionSelector = new CurrentImplementationApiVersionSelector(options);
            })
            .AddMvc() // This is needed for controllers
            .AddApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'V";
                options.SubstituteApiVersionInUrl = true;
            });

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", $"{Title} V1");
                c.SwaggerEndpoint("/swagger/v2/swagger.json", $"{Title} V2");
                c.SwaggerEndpoint("/swagger/v3/swagger.json", $"{Title} V3");
            });
        }

        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();

        app.Run();
    }
}