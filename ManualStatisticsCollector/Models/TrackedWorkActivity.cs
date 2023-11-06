using ManualStatisticsCollectorLib.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManualStatisticsCollector.Models
{
    public class TrackedWorkActivity 
    {
        public WorkActivity WorkActivity { get; }

        public bool Uploaded { get; set; } = false;
        public TrackedWorkActivity(WorkActivity workActivity)
        {
            WorkActivity = workActivity;
        }

        
        
    }
}
