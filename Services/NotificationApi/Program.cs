
using NotificationApi.Repository;
using Microsoft.Extensions.Configuration;

using NotificationApi.model;

namespace NotificationApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddHttpClient<NovuService>();

            builder.Services.Configure<TwilioOptions>(builder.Configuration.GetSection("Twilio"));
            builder.Services.AddSingleton<TwilioSmsService>(serviceProvider =>
            {
                var twilioOptions = builder.Configuration.GetSection("Twilio").Get<TwilioOptions>();
                return new TwilioSmsService(twilioOptions.AccountSid, twilioOptions.AuthToken, twilioOptions.PhoneNumber);
            });

            builder.Services.AddControllers();
            builder.Services.AddHttpClient<EmailService>();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();
            app.UseCors(x=>x.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

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
