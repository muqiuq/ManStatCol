using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManualStatisticsCollector
{
    public class ManStatColSettings
    {
        public string TrackingProject { get; set; } = "";

        public string UpdateUrl { get; set; } = "";

        private string path = "";

        public List<string> WorkActivities { get; set; } = new List<string>();

        public ManStatColSettings() { }

        public ManStatColSettings(string path)
        {
            this.path = path;
        }

        public void Save()
        {
            if(path != "")
            {
                var jsonObject = JsonConvert.SerializeObject(this);
                File.WriteAllText(path, jsonObject);
            }
        }

        public static ManStatColSettings? Load(string path) { 
            var jsonObject = File.ReadAllText(path);
            var settings = JsonConvert.DeserializeObject<ManStatColSettings>(jsonObject);
            settings.path = path;
            return settings;
        }

    }
}
