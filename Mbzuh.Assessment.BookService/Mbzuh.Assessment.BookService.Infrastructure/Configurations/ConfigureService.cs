using Mbzuh.Assessment.BookService.Infrastructure.Persistence.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace Mbzuh.Assessment.BookService.Infrastructure.Configurations
{
    public static class ConfigureService
    {
        public static IServiceCollection ConfigureBookServiceInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            //In-Memory database or SQL server
            if (Convert.ToBoolean(configuration.GetSection("UseInMemoryDatabase").Value))
                services.AddDbContext<ApplicationDbContext>(options => options.UseInMemoryDatabase("MbzudAssessmentDb"));
            else
                services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                        builder => builder.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            //context/intializer/seeder injections
            services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());
            services.AddScoped<ApplicationDbContextInitializer>();
            services.AddScoped<ApplicationDbContextDataSeeding>();

            //Newton json ignoring reference loop
            JsonConvert.DefaultSettings = () => new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            return services;
        }
    }
}
