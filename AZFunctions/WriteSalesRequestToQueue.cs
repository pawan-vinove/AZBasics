using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json; 
using AZFunctions.Models;
using Microsoft.Azure.WebJobs.Description;

namespace AZFunctions
{
    public static class WriteSalesRequestToQueue
    {
        [FunctionName("WriteSalesRequestToQueue")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            [Queue("salesrequestinboundtest",Connection = "AzureWebJobsStorage")] IAsyncCollector<SalesRequest>salesRequestQueue,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");         

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            SalesRequest data = JsonConvert.DeserializeObject<SalesRequest>(requestBody);
            //name = name ?? data?.name;
            await salesRequestQueue.AddAsync(data);
            string responseMessage ="SalesRequest has been received for data "+data.Name;

            return new OkObjectResult(responseMessage);
        }
    }
}
