
using CommonLibrary;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using UserApi.Data;
using UserApi.Repository;
using UserApi.Repository.IRepository;

namespace UserApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddDbContext<UserDBContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultDB")));
            builder.Services.AddTransient<IUserRepository,UserRepository>();


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
            app.UseCors(x=>x.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
