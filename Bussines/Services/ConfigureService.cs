using Data;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussines.Services
{
    //public class ConfigureService
    //{
    //    public void ConfigureServices(IServiceCollection services)
    //    {
    //        // Добавляем контекст базы данных
    //        services.AddDbContext<ApplicationDbContext>(options =>
    //            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

    //        // Добавляем Identity
    //        services.AddIdentity<ApplicationUser, IdentityRole>()
    //            .AddEntityFrameworkStores<ApplicationDbContext>()
    //            .AddDefaultTokenProviders();

    //        // Настраиваем аутентификацию через JWT
    //        services.AddAuthentication(options =>
    //        {
    //            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    //            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    //        })
    //            .AddJwtBearer(options =>
    //            {
    //                options.RequireHttpsMetadata = false;
    //                options.SaveToken = true;
    //                options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    //                {
    //                    ValidateIssuer = true,
    //                    ValidateAudience = true,
    //                    ValidateLifetime = true,
    //                    ValidateIssuerSigningKey = true,
    //                    ValidIssuer = Configuration["Jwt:Issuer"],
    //                    ValidAudience = Configuration["Jwt:Issuer"],
    //                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
    //                };
    //            });
    //    }
    //}
}
