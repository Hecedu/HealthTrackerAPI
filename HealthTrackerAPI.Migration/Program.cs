using System;
using System.IO;
using HealthTrackerAPI.Authentication;
using HealthTrackerAPI.Migration;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;

namespace LearningAnalytics.Migration
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Applying migrations");
            var webHost = new WebHostBuilder()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseStartup<ConsoleStartup>()
                .Build();

            using (var context = (ApplicationDbContext)webHost.Services.GetService(typeof(ApplicationDbContext)))
            {
                context.Database.Migrate();
                context.Database.EnsureCreated();
            }
            Console.WriteLine("Done");
        }
    }
}