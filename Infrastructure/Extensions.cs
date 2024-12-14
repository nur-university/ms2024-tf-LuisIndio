using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Application;
using Domain.Repositories;
using Infrastructure.DomainModel;
using Infrastructure.Repositories;
using Infrastructure.StoredModel;
using Inventory.Domain.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class Extensions
    {
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(config =>
            {
                config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            });

            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<StoredDbContext>(context =>
                    context.UseMySql(connectionString,
                        ServerVersion.AutoDetect(connectionString)));

            services.AddDbContext<DomainDbContext>(context =>
                    context.UseMySql(connectionString,
                        ServerVersion.AutoDetect(connectionString)));


            services.AddScoped<INutritionistRepository, NutritionistRepository>();
            services.AddScoped<IAnalysisRequestRepository, AnalysisRequestRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddAplication();

            return services;
        }
}
}
