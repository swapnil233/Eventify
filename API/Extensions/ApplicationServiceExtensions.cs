using Application.Activities;
using Application.Core;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Extensions;

public static class ApplicationServiceExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
    {
        // SQLite DB Service
        services.AddDbContext<DataContext>(options =>
        {
            options.UseSqlite(config.GetConnectionString("DefaultConnection"));
        });

        // Cors Service
        services.AddCors(options => {
            options.AddPolicy("CorsPolicy", policy => {
                policy.AllowAnyMethod().AllowAnyHeader().WithOrigins("http://localhost:3000");
            });
        });

        // Mediator Service. 
        services.AddMediatR(typeof(List.Handler));

        // AutoMapper Service
        services.AddAutoMapper(typeof(MappingProfiles).Assembly);

        return services;
    }
}
