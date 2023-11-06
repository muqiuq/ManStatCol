using ManStatColService.DbEntities;
using ManualStatisticsCollectorLib.Entities;
using System;

namespace ManStatColService.Extensions
{
    public static class WorkActivityTableExtensions
    {
        public static WorkActivityTable ToTable(this WorkActivity workActivity)
        {
            return new WorkActivityTable()
            {
                PartitionKey = "WorkActivity",
                RowKey = Guid.NewGuid().ToString(),
                Start = workActivity.Start,
                End = (DateTime)workActivity.End,
                Source = workActivity.Source,
                Duration = (TimeSpan)workActivity.Duration,
                TrackingProject = workActivity.TrackingProject,
                WorkTask= workActivity.WorkTask,
                Id = workActivity.Id,
            };
        }
    }
}
