using Azure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManStatColService.DbEntities
{
    public class WorkActivityTable : Azure.Data.Tables.ITableEntity
    {
        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public Guid Id { get; set; }

        public TimeSpan Duration { get; set; }

        public string Source { get; set; }

        public string WorkTask { get; set; }

        public string TrackingProject { get; set; }
        public string PartitionKey { get; set; }
        public string RowKey { get; set; }
        public DateTimeOffset? Timestamp { get; set; }
        public ETag ETag { get; set; }
    }
}
