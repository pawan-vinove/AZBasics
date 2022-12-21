using System;
using AZFunctions.Data;
using AZFunctions.Models;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace AZFunctions
{
    public class OnQueueTriggerUpdateDatabase
    {
        private readonly AZFunctionDbContext _dbAZFunctionDbContext;
        public OnQueueTriggerUpdateDatabase(AZFunctionDbContext dbAZFunctionDbContext)
        {
            _dbAZFunctionDbContext = dbAZFunctionDbContext;
        }
        [FunctionName("OnQueueTriggerUpdateDatabase")]
        public void Run([QueueTrigger("salesrequestinbound", Connection = "AzureWebJobsStorage")]SalesRequest myQueueItem//, ILogger log
            )
        {
            //log.LogInformation($"C# Queue trigger function processed: {myQueueItem}");
            myQueueItem.Status = "Submitted";
            _dbAZFunctionDbContext.SalesRequests.Add(myQueueItem);
            _dbAZFunctionDbContext.SaveChanges();
        }
    }
}
