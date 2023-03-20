
namespace Microsoft.Extensions.DependencyInjection;
using Microsoft.Data.Sqlite;
using Microsoft.OpenApi.Models;
using MinimalApiPaladino.Data;

public static class ServicesCollectionExtensions
{
    public static WebApplicationBuilder AddSwagger(this WebApplicationBuilder builder)
    {
        builder.Services.AddSwagger();
        return builder;
    }

    public static IServiceCollection AddSwagger(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo()
            {
            });
        });
        return services;
    }

    public static WebApplicationBuilder AddPersistence(this WebApplicationBuilder builder)
    {
        var connectionString = builder.Configuration.GetConnectionString("SqliteConnectionString")
          ?? "Data Source=PaladinoDB.db";

        builder.Services.AddSqlite<PaladinoDbContext>(connectionString);

        builder.Services.AddScoped(_ => new SqliteConnection(connectionString));

        return builder;
    }


}
