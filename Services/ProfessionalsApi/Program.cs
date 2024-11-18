
using Microsoft.EntityFrameworkCore;
using ProfessionalsApi.Data;
using ProfessionalsApi.Repository;
using ProfessionalsApi.Repository.IRepository;

namespace ProfessionalsApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddDbContext<ProfessionalApiContext>(opt=>opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultDB")));
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddTransient<IProfessionalRepository,ProfessionalRepository>();
            builder.Services.AddTransient<IReviewRepository, ReviewRepository>();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();
            app.UseCors(x => x.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
