using System;
using HealthTrackerAPI.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HealthTrackerAPI.Migration
    {
        public class ConsoleStartup
        {
            public ConsoleStartup()
            {
                var builder = new ConfigurationBuilder()
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                    .AddEnvironmentVariables();
                Configuration = builder.Build();

                //.. for test
                Console.WriteLine(Configuration.GetConnectionString("ConStr"));
            }

            public IConfiguration Configuration { get; }

            public void ConfigureServices(IServiceCollection services)
            {
                services.AddDbContext<ApplicationDbContext>(options =>
                {
                    options.UseSqlServer(Configuration.GetConnectionString("ConStr"));

                });
            }

            public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
            {

            }
        }
    }
