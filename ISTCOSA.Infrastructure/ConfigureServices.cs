using ISTCOSA.Application.Interfaces;
using ISTCOSA.Infrastructure.Data;
using ISTCOSA.Infrastructure.Utility;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ISTCOSA.Infrastructure
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("ConStr"));
            });

            services.AddScoped<IApplicationDBContext, ApplicationDbContext>();
            services.AddMediatR(ctg =>
            {
                ctg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            });
               services.AddScoped<IEmailSender, EmailService>();
               services.Configure<EmailSetting>(configuration.GetSection("EmailSetting"));
            //services.AddAutoMapper(Assembly.GetExecutingAssembly());
            //services.AddAutoMapper(typeof(MappingProfile));
            return services;
        }
    }
}
