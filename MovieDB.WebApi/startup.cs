using MovieDB.Infra.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace developChallenge.Web.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {

            //sql server
            //var connectionString = Configuration.GetConnectionString("DefaultConnection");
            //services.AddDbContext<MyDatabaseContext>(options =>
            //    options.UseSqlServer(connectionString));

            //MySQL
            var connectionString = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<MyContextDatabase>(options =>
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
            );


        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseAuthentication();
        }
    }
}