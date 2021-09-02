using Hellang.Middleware.ProblemDetails;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using RPG.Data.Context;
using RPG.Data.Repository.AuthRepository;
using RPG.Data.Repository.CharacterRepository;
using RPG.Data.Repository.SkillRepository;
using RPG.Data.Repository.WeaponRepository;
using RPG.Services.AuthService;
using RPG.Services.CharacterService;
using System.Text;

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
                .EnableSensitiveDataLogging()
            );
            services.AddProblemDetails();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII
                            .GetBytes(Configuration.GetSection("AppSettings:Token").Value)),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });

            //Repose
            services.AddScoped<ICharacterRepository, CharacterRepository>();
            services.AddScoped<IAuthRepository, AuthRepository>();
            services.AddScoped<IWeaponRepository, WeaponRepository>();
            services.AddScoped<ISkillRepository, SkillRepository>();
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

            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
