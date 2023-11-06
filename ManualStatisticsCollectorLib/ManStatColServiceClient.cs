using ManualStatisticsCollectorLib.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManualStatisticsCollectorLib
{
    public static class ManStatColServiceClient
    {

        public static async Task<WorkActivitiesSubmitResult> SubmitWorkActivities(string url, List<WorkActivity> workActivities)
        {
            using HttpClient client = new();
            var requestMessage = new HttpRequestMessage(HttpMethod.Post, url);
            requestMessage.Content = new StringContent(JsonConvert.SerializeObject(workActivities), Encoding.UTF8, "application/json");
            var result = client.Send(requestMessage);
            if (!result.IsSuccessStatusCode)
            {
                throw new GeneralSubmissionException($"Submission failed with status code {result.StatusCode}");
            }
            string rawResultContent = await result.Content.ReadAsStringAsync();
            var resultContent = JsonConvert.DeserializeObject<WorkActivitiesSubmitResult>(rawResultContent);
            if (resultContent == null || resultContent.Success == false)
            {
                throw new GeneralSubmissionException($"Submission failed with message: \"{resultContent.Message}\"");
            }
            return resultContent;
        }

    }
}
