using FirstWebApi.Services.Interfaces;
using FirstWebApi.Services;
using Microsoft.Extensions.DependencyInjection;
using FirstWebApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace FirstWebApi.Config
{
    public static class MyConfigServiceCollectionExtensions
    {
        public static IServiceCollection AddConfig(
            this IServiceCollection services, IConfiguration config)
        {
            services.Configure<AppSettings>(config.GetSection("JWT"));
            services.AddDbContext<MyDbContext>(options =>
            {
                options.UseSqlServer(config.GetConnectionString("DefaultConnection"));
            });
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    //ValidateIssuer = true,
                    //ValidateAudience = true,
                    //ValidAudience = config["JWT:ValidAudience"],
                    //ValidIssuer = config["JWT:ValidIssuer"],

                    //tự cấp token
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    
                    //signin token
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JWT:SecretKey"])),
                    ClockSkew = TimeSpan.Zero,
                };


            });
            return services;

        }
        public static IServiceCollection AddMyDependencyGroup(
             this IServiceCollection services)
        {
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            return services;
        }
    }
}
