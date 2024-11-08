using System;
using System.Collections;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;


namespace Company.Function
{
   public class GetResumeCounter
    {
        private readonly ILogger<GetResumeCounter> _logger;

        public GetResumeCounter(ILogger<GetResumeCounter> logger)
        {
            _logger = logger;
        }

        
        [Function(nameof(GetResumeCounter))]
         /*[CosmosDBOutput("AzureResume", "Counter", Connection = "AzureResumeConnectionString", CreateIfNotExists = true)]*/
         public   HttpResponseMessage Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequest req,
        [CosmosDBInput(
                databaseName: "AzureResume",
                containerName: "Counter",
                Connection = "AzureResumeConnectionString",
                Id = "1",
                PartitionKey = "1")] Counter counter,
            FunctionContext context        
        )
        
        {
             _logger.LogInformation("Processing request to get and update resume counter.");

           // Increment the counter
            Counter updatedCounter;

            updatedCounter = counter;

            updatedCounter.Count += 1;

            // Use output binding to persist the updated counter in Cosmos DB
            /*counter.Add(counter);*/

            // Return the current count as JSON
            var jsonToReturn = JsonConvert.SerializeObject(counter);

            return new HttpResponseMessage(System.Net.HttpStatusCode.OK)
            {
                Content = new StringContent(jsonToReturn, Encoding.UTF8, "application/json")
            };
    }
    }
}
