using Microsoft.Azure.WebJobs.Hosting;
using Microsoft.Azure.WebJobs;
using System;
using Microsoft.Extensions.DependencyInjection;
using AZFunctions.Data;
using AZFunctions;
using Microsoft.EntityFrameworkCore;

[assembly: WebJobsStartup(typeof(Startup))]
namespace AZFunctions
{   
    public class Startup : IWebJobsStartup
    {
        public void Configure(IWebJobsBuilder builder)
        {
            string connectionString = Environment.GetEnvironmentVariable("AzureSqlDatabase");

            builder.Services.AddDbContext<AZFunctionDbContext>(
                options => options.UseSqlServer(connectionString));

            builder.Services.BuildServiceProvider();
        }
    }
}
