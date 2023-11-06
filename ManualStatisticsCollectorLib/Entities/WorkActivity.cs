using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ManualStatisticsCollectorLib.Entities
{
    public class WorkActivity
    {
        public string WorkTask { get; set; } = "Default";
        public DateTime Start { get; private set; }

        public DateTime? End { get; private set; }

        public Guid Id { get; private set; }

        [JsonIgnore]
        public TimeSpan Duration 
        { 
            get 
            {
                if(End == null)
                {
                    return GetDurationUntilNow();
                }
                return (TimeSpan)(End - Start);
            }
        }

        public string? Source { get; private set; }

        public string TrackingProject { get; private set; }

        public string Name { get; set; } = "";

        public bool IsPaused { get; private set; } = false;

        public DateTime? ContinuedOn { get; private set; }

        
        public WorkActivity() { }

        [JsonConstructor]
        public WorkActivity(string workTask, DateTime start, DateTime? end, Guid id, string? source, string trackingProject, string name, bool isPaused, DateTime? continuedOn)
        {
            WorkTask = workTask;
            Start = start;
            End = end;
            Id = id;
            Source = source;
            TrackingProject = trackingProject;
            Name = name;
            IsPaused = isPaused;
            ContinuedOn = continuedOn;
        }

        public static WorkActivity StartNew(string source, string trackingProject, string workTaskType)
        {
            return new WorkActivity
            {
                Start = DateTime.Now,
                Id = Guid.NewGuid(),
                Source = source,
                TrackingProject = trackingProject,
                WorkTask = workTaskType
            };
        }

        public void Stop()
        {
            updateEnd();
            IsPaused = false;
        }

        [JsonIgnore]
        public bool IsFinished
        {
            get
            {
                return End != null && !IsPaused;
            }
        }

        public TimeSpan GetDurationUntilNow()
        {
            if(ContinuedOn!= null)
            {
                return (TimeSpan)((End - Start) + (DateTime.Now - ContinuedOn));
            }
            return DateTime.Now - Start;
        }

        private void updateEnd()
        {
            if (ContinuedOn != null)
            {
                End = End + (DateTime.Now - ContinuedOn);
            }
            else
            {
                End = DateTime.Now;
            }
        }

        public void Pause()
        {
            IsPaused = true;
            updateEnd();
        }

        public void Continue()
        {
            ContinuedOn = DateTime.Now;
            IsPaused = false;
        }

        public override string ToString()
        {
            var name = Name;
            if (name == "") Name = TrackingProject;
            return $"({WorkTask}) {Name}: {Duration.ToString("hh\\:mm\\:ss")}";
        }
    }
}
