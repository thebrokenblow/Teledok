using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Teledok.Application.Repositories.Interfaces;
using Teledok.Persistence.Repositories;

namespace Teledok.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration["DbConnection"];
        services.AddDbContext<TeledokDbContext>(options =>
        {
            options.UseSqlServer(connectionString);
        });

        services.AddScoped<IRepositoryClient, RepositoryClient>();
        services.AddScoped<IRepositoryFounder, RepositoryFounder>();

        return services;
    }
}