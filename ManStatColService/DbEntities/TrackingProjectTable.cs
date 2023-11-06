using Azure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManStatColService.DbEntities
{
    public class TrackingProjectTable : Azure.Data.Tables.ITableEntity
    {

        public bool Enabled { get; set; }
        public string Company { get; set; }
        public string Name { get; set; }
        public string PartitionKey { get; set; }
        public string RowKey { get; set; }
        public DateTimeOffset? Timestamp { get; set; }
        public ETag ETag { get; set; }

    }
}
