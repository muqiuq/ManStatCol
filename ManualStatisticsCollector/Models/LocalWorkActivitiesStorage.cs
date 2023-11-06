using ManualStatisticsCollectorLib;
using ManualStatisticsCollectorLib.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManualStatisticsCollector.Models
{
    public class LocalWorkActivitiesStorage
    {

        public delegate void UploadResultDelegate(bool success, string message, bool forcedUpload);
        
        private List<TrackedWorkActivity> _trackedWorkActivities = new List<TrackedWorkActivity>();
        private Thread uploadThread;
        private readonly string filePath;

        public LocalWorkActivitiesStorage(string filePath)
        {
            this.filePath = filePath;
        }

        internal void Add(WorkActivity currentWorkActivity)
        {
            if(!_trackedWorkActivities.Where(c => c.WorkActivity == currentWorkActivity).Any())
            {
                _trackedWorkActivities.Add(
                    new TrackedWorkActivity(currentWorkActivity)
                    );
            }
            Save();
        }

        public void Load()
        {
            var jsonArray = File.ReadAllText(filePath);
#pragma warning disable CS8601 // Possible null reference assignment.
            _trackedWorkActivities = JsonConvert.DeserializeObject<List<TrackedWorkActivity>>(jsonArray);
#pragma warning restore CS8601 // Possible null reference assignment.
        }

        public void Save()
        {
            var jsonArray = JsonConvert.SerializeObject(_trackedWorkActivities);
            File.WriteAllText(filePath, jsonArray);
        }

        public void Upload(string url, UploadResultDelegate uploadResultDelegate, bool forcedUpload)
        {
            if (uploadThread == null || !uploadThread.IsAlive)
            {
                uploadThread = new Thread(() =>
                {
                    string message = "";
                    var success = false;
                    try
                    {
                        var workActivitiesToSend = _trackedWorkActivities.Where(i => !i.Uploaded && !i.WorkActivity.IsPaused).Select(p => p.WorkActivity).ToList();
                        if(workActivitiesToSend.Count == 0 && !forcedUpload) {
                            return;
                        }
                        Debug.WriteLine($"Sending {workActivitiesToSend.Count} activities");
                        var resultTask = ManStatColServiceClient.SubmitWorkActivities(url, workActivitiesToSend
                            );
                        resultTask.Wait();
                        var result = resultTask.Result;
                        _trackedWorkActivities.Where(t => 
                            result.AcceptedIds.Contains(t.WorkActivity.Id) || result.ExistingIds.Contains(t.WorkActivity.Id)
                        ).ToList().ForEach(t => t.Uploaded = true);
                        message = $"Received confirmation for accepted ids of {result.AcceptedIds.Count} and existing ids of {result.ExistingIds.Count}";
                        Save();
                        success = true;
                        message += " and saved file";
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.ToString());
                        message += "\n" + ex.ToString();
                    }
                    uploadResultDelegate(success, message, forcedUpload);
                });
                uploadThread.Start();
            }
        }

        internal List<WorkActivity> GetPausedActivities()
        {
            return _trackedWorkActivities.Where(i => i.WorkActivity.IsPaused).Select(p => p.WorkActivity).ToList();
        }

        internal void Remove(WorkActivity currentWorkActivity)
        {
            var searchResultToDelete = _trackedWorkActivities.Where(c => c.WorkActivity == currentWorkActivity).FirstOrDefault();
            if(searchResultToDelete!= null)
            {
                _trackedWorkActivities.Remove(searchResultToDelete);
            }
            Save();
        }

        internal List<WorkActivity> GetAllActivities()
        {
            return _trackedWorkActivities.Select(t => t.WorkActivity).ToList();
        }
    }
}
