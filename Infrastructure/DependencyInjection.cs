using Application.Interfaces;
using Infrastructure.Components;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;

namespace Infrastructure;

public  static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration _configuration)
    {   
             
        services.AddDbContext<ApartmentDetailsDbContext>(options => {
            MySqlConnectionStringBuilder connectionBuilder = new MySqlConnectionStringBuilder();
            
            connectionBuilder.Password = _configuration["DbPassword"];
            connectionBuilder.UserID = _configuration["DbUserName"];
            connectionBuilder.Server = _configuration["DbHost"];
            connectionBuilder.Database = _configuration["DbName"];
            connectionBuilder.CharacterSet = "utf8mb4";
            connectionBuilder.UseCompression = true;
            connectionBuilder.ConvertZeroDateTime = true;

            string connectionString = connectionBuilder.ConnectionString;

            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString), b =>

                    b.MigrationsAssembly(typeof(ApartmentDetailsDbContext).Assembly.FullName)
                        .EnableRetryOnFailure(maxRetryCount: 5, maxRetryDelay: TimeSpan.FromSeconds(30),
                            errorNumbersToAdd: null)
                )
                .EnableSensitiveDataLogging();
        });
		
        services.AddScoped<IApplicationDBContext>(provider => provider.GetRequiredService<ApartmentDetailsDbContext>());

        return services;
    }
}