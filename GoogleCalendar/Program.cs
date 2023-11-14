

using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System.Net.Http;

namespace GoogleCalendar
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();



            //var serviceProvider = builder.Services.BuildServiceProvider();
            //var httpClientFactory = serviceProvider.GetRequiredService<IHttpClientFactory>();
            //var calendarService = new CalendarService(new BaseClientService.Initializer
            //{
            //    HttpClientInitializer =  GoogleCredential.GetApplicationDefault(),
            //    HttpClientFactory = (Google.Apis.Http.IHttpClientFactory)httpClientFactory.CreateClient(),
            //    ApplicationName = "Calender"
            //});
            //.AddAuthentication(o =>
            //{
            //    o.DefaultScheme = GoogleOpenIdConnectDefaults.AuthenticationScheme;
            //    o.DefaultChallengeScheme = GoogleOpenIdConnectDefaults.AuthenticationScheme;
            //})
            //.AddGoogleOpenIdConnect(options =>
            //{
            //    options.ClientId = 
            //    options.ClientSecret = 

            //});
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
            })
            .AddCookie()
            .AddGoogle(options =>
            {
                options.ClientId = "1072774439376-m2hc8qk9aaeosk0o70tl91q5e4a2ld42.apps.googleusercontent.com";
                options.ClientSecret = "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";
            });
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}