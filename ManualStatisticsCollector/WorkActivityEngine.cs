using ManualStatisticsCollector.Models;
using ManualStatisticsCollectorLib;
using ManualStatisticsCollectorLib.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ManualStatisticsCollector.Models.LocalWorkActivitiesStorage;

namespace ManualStatisticsCollector
{
    public class WorkActivityEngine
    {

        private WorkActivity? _currentWorkActivity;

        private LocalWorkActivitiesStorage storage;
        public ManStatColSettings Settings;

        public WorkActivityEngine()
        {
            var settingsPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "manstatcol-settings.json");
            ManStatColSettings? settings = null;
            if (File.Exists(settingsPath))
            {
                settings = ManStatColSettings.Load(settingsPath);
                if(settings != null)
                {
                    Settings = settings;
                }
            }
            if(settings == null)
            {
                Settings = new ManStatColSettings(settingsPath);
            }

            var storagePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "manstatcol-storage.json");
            storage = new LocalWorkActivitiesStorage(storagePath);
            try
            {
                storage.Load();
            }
            catch(FileNotFoundException ex) { }
            finally { }

        }

        public List<string> GetWorkActivitiesTypes()
        {
            return Settings.WorkActivities;
        }

        public void SyncWorkActivitiesType(IEnumerable<string> otherWorkActivities)
        {
            var changes = 0;
            var activitiestoAdd = otherWorkActivities.Where(i => !Settings.WorkActivities.Contains(i)).ToList();
            changes += activitiestoAdd.Count;
            activitiestoAdd.ForEach(i => Settings.WorkActivities.Add(i));
            var activitiesToRemove = Settings.WorkActivities.Where(i => !otherWorkActivities.Contains(i)).ToList();
            changes += activitiesToRemove.Count;
            activitiesToRemove.ForEach(i => Settings.WorkActivities.Remove(i));
            if(changes > 0)
            {
                Settings.Save();
            }
        }


        public bool TrackingProjectRequired { get
            {
                return Settings.TrackingProject == null || Settings.TrackingProject == "";
            } 
        }

        public string GetElapsedTime()
        {
            if(_currentWorkActivity == null)
            {
                return "";
            }
            return _currentWorkActivity.GetDurationUntilNow().ToString("hh\\:mm\\:ss");
        }

        public WorkActivity StartActivity(string workTaskType)
        {
            _currentWorkActivity = WorkActivity.StartNew(
                $"{System.Environment.MachineName.Replace(";", "")};{System.Environment.UserName.Replace(";", "")}",
                Settings.TrackingProject,
                workTaskType
                );
            return _currentWorkActivity;
        }

        public WorkActivity? PauseActivity()
        {
            if (_currentWorkActivity == null) return null;
            _currentWorkActivity.Pause();
            storage.Add(_currentWorkActivity);
            var pausedActivity = _currentWorkActivity;
            _currentWorkActivity = null;
            return pausedActivity;
        }

        public List<WorkActivity> PausedActivities()
        {
            return storage.GetPausedActivities();
        }

        public bool StopActivity() {
            if (_currentWorkActivity == null) return false;
            _currentWorkActivity.Stop();
            if (_currentWorkActivity.Duration < TimeSpan.FromSeconds(5))
            {
                _currentWorkActivity = null;
                return false;
            }
            else
            {
                storage.Add(_currentWorkActivity);
                _currentWorkActivity = null;
                return true;
            }
        }
        
        public bool IsActivityActive()
        {
            return _currentWorkActivity != null;
        }

        internal void Upload(UploadResultDelegate uploadResultDelegate, bool forcedUpload = false)
        {
            if (Settings.UpdateUrl == "") return;
            storage.Upload(Settings.UpdateUrl, uploadResultDelegate, forcedUpload);
        }

        internal void ContinueActivity(WorkActivity activityToContinue)
        {
            _currentWorkActivity = activityToContinue;
            _currentWorkActivity.Continue();
        }

        internal void RemoveActivity(WorkActivity activity)
        {
            storage.Remove(activity);
        }

        internal void CancelActivity()
        {
            if (_currentWorkActivity == null) return;
            storage.Remove(_currentWorkActivity);
            _currentWorkActivity = null;
        }

        internal string GetElapsedTimeWithName()
        {
            if (_currentWorkActivity == null) return "N/A";
            return (_currentWorkActivity.Name + " " + GetElapsedTime()).Trim();
        }

        internal List<WorkActivity> GetAllActivities()
        {
            return storage.GetAllActivities();
        }
    }
}
