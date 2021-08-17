using Hellang.Middleware.ProblemDetails;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RPG.Data.Context;
using RPG.Data.Repository.AuthRepository;
using RPG.Data.Repository.CharacterRepository;
using RPG.Services.AuthService;
using RPG.Services.CharacterServices;

namespace RPG.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddAutoMapper(typeof(Data.Profiles.MapperProfile).Assembly);
            services.AddDbContext<DataContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefultConnection"))
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
            );
            services.AddProblemDetails();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                });

            //Repose
            services.AddScoped<ICharacterRepository, CharacterRepository>();
            services.AddScoped<IAuthRepository, AuthRepository>();
            //Services
            services.AddScoped<ICharacterService, CharacterService>();
            services.AddScoped<IAuthService, AuthService>();

        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseProblemDetails();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
