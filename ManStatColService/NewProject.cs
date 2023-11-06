using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Azure.Data.Tables;
using ManStatColService.DbEntities;
using System.Linq;
using Azure;

namespace ManStatColService
{
    public static class NewProjectFunction
    {
        [FunctionName("newproject")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
            [Table(StaticDefinitions.TrackingProjectTableName, Connection = "AzureWebJobsStorage")] IAsyncCollector<TrackingProjectTable> trackingProjectCollector,
            [Table(StaticDefinitions.TrackingProjectTableName, Connection = "AzureWebJobsStorage")] TableClient tableClientTrackingProject,
            ILogger log)
        {
            string name;
            string company;
            
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            name = data?.name;
            company = data?.company;

            if(name == null || company == null || name.Trim() == "" || company.Trim() == "")
            {
                return new OkObjectResult(JsonConvert.SerializeObject(new { success = false, message = "name or company cannot be empty" }));
            }

            if(!tableClientTrackingProject.Query<TrackingProjectTable>().Where(i => i.Name == name).Any())
            {
                await trackingProjectCollector.AddAsync(new TrackingProjectTable()
                {
                    PartitionKey = "TrackingProject",
                    RowKey = Guid.NewGuid().ToString(),
                    Name = name,
                    Company = company,
                    Enabled = true,
                });
                return new OkObjectResult(JsonConvert.SerializeObject(new {success = true, message = "added"}));
            }
            else
            {
                return new OkObjectResult(JsonConvert.SerializeObject(new { success = false, message = "project exists" }));
            }
        }
    }
}
