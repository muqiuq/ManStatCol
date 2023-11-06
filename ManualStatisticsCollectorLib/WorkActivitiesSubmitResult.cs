using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManualStatisticsCollectorLib
{
    public class WorkActivitiesSubmitResult
    {

        [JsonProperty("success")]
        public readonly bool Success;

        [JsonProperty("message")]
        public readonly string Message;

        [JsonProperty("acceptedids")]
        public readonly List<Guid> AcceptedIds;

        [JsonProperty("existingids")]
        public readonly List<Guid> ExistingIds;

        public WorkActivitiesSubmitResult(bool success, string message)
        {
            Success = success;
            Message = message;
            AcceptedIds= new List<Guid>();
            ExistingIds= new List<Guid>();
        }

        [JsonConstructor]
        public WorkActivitiesSubmitResult(bool success, string message, List<Guid> acceptedIds, List<Guid> existingIds)
        {
            Success = success;
            Message = message;
            AcceptedIds = acceptedIds;
            ExistingIds = existingIds;
        }
    }
}
