using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using ManualStatisticsCollectorLib.Entities;
using System.Collections.Generic;
using Azure.Data.Tables;
using ManStatColService.DbEntities;
using System.Linq;
using ManStatColService.Extensions;
using ManualStatisticsCollectorLib;

namespace ManStatColService
{
    public static class SubmitFunction
    {
        [FunctionName("submit")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            [Table(StaticDefinitions.WorkActivityTableName, Connection = "AzureWebJobsStorage")] IAsyncCollector<WorkActivityTable> workActivityCollector,
            [Table(StaticDefinitions.WorkActivityTableName, Connection = "AzureWebJobsStorage")] TableClient tableClientWorkActivity,
            [Table(StaticDefinitions.TrackingProjectTableName, Connection = "AzureWebJobsStorage")] TableClient tableClientTrackingProject,
            ILogger log)
        {

            var response = new WorkActivitiesSubmitResult(false, "error");

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var workActivities = JsonConvert.DeserializeObject<List<WorkActivity>>(requestBody);

            var numberOfAcceptedWorkActivites = 0;
            List<Guid> acceptedIds = new List<Guid>();
            List<Guid> existingIds = new List<Guid>();

            foreach(var workActivity in workActivities)
            {
                var trackingProject = tableClientTrackingProject.Query<TrackingProjectTable>().Where(i => i.Name == workActivity.TrackingProject && i.Enabled).FirstOrDefault();
                if(trackingProject == null) {
                    response = new WorkActivitiesSubmitResult(false, "invalid tracking project");
                }
                else
                {
                    var workActivityExists = tableClientWorkActivity.Query<WorkActivityTable>().Where(i => i.Id== workActivity.Id).Any();
                    if(!workActivityExists) {
                        await workActivityCollector.AddAsync(workActivity.ToTable());
                        numberOfAcceptedWorkActivites++;
                        acceptedIds.Add(workActivity.Id);
                    }
                    else
                    {
                        existingIds.Add(workActivity.Id);
                    }
                }
            }

            response = new WorkActivitiesSubmitResult(true, 
                $"added {numberOfAcceptedWorkActivites} of the submitted {workActivities.Count}", 
                acceptedIds, existingIds);

            return new OkObjectResult(JsonConvert.SerializeObject(response));
        }
    }
}
