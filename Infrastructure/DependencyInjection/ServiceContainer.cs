using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Infrastructure.Data;
using Application.Interfaces;
using Infrastructure.Repositories;
using Domain.Entities;
using Infrastructure.Identity;

namespace Infrastructure.DependencyInjection
{ 
    public static class ServiceContainer
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
             // Register other infrastructure services here

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("CRMDemoMSSQLConnection")), ServiceLifetime.Scoped);

           
           // Register repositories

            services.AddScoped<ICustomer, CustomerRepository>();
            services.AddScoped<ICampaign, CampaignRepository>();
            services.AddScoped<ISupportTicket, SupportTicketRepository>();
            services.AddScoped<IIdentity, IdentityRepos>();
            services.AddAuthenticationService(configuration);

            return services;
        }
    }
}