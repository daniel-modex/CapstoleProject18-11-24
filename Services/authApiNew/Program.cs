
using authApiNew.Data;
using authApiNew.models;
using authApiNew.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

namespace authApiNew
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            //var jwtsettings = new JwtOptions();

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddDbContext<AuthApiContext>(x=>x.UseSqlServer(builder.Configuration.GetConnectionString("DefaultDB")));
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<AuthApiContext>().AddDefaultTokenProviders();
            builder.Services.AddTransient<IRegisterService, RegisterService>();
            builder.Services.AddTransient<ITokenGenerator,TokenGenerator>();
            var jwtOptions = new JwtOptions
            {
                Secret = Environment.GetEnvironmentVariable("JWT_SECRET"),
                Issuer = Environment.GetEnvironmentVariable("JWT_ISSUER"),
                Audience = Environment.GetEnvironmentVariable("JWT_AUDIENCE")
            };
            if (string.IsNullOrWhiteSpace(jwtOptions.Secret) ||
            string.IsNullOrWhiteSpace(jwtOptions.Issuer) ||
            string.IsNullOrWhiteSpace(jwtOptions.Audience))
            {
                throw new ArgumentException("JWT settings are not properly configured in the environment variables.");
            }
            //builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection("ApiSettings:JwtOptions"));
            //builder.Configuration.GetSection("ApiSettings:JwtOptions").Bind(jwtsettings);
            builder.Services.Configure<JwtOptions>(opts =>
            {
                opts.Secret = jwtOptions.Secret;
                opts.Issuer = jwtOptions.Issuer;
                opts.Audience = jwtOptions.Audience;
            });

            builder.Services.AddAuthentication(options =>

            {

                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;

                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(options =>

            {

                options.TokenValidationParameters = new TokenValidationParameters

                {

                    ValidateIssuer = true,

                    ValidateAudience = true,

                    ValidateLifetime = true,

                    ValidateIssuerSigningKey = true,

                    ValidIssuer = jwtOptions.Issuer,

                    ValidAudience = jwtOptions.Audience,

                    RoleClaimType = ClaimTypes.Role,

                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtOptions.Secret))

                };

            });

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseCors(x=>x.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
            app.UseHttpsRedirection();

            app.UseAuthentication();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
