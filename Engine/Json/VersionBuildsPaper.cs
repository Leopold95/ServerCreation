using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reactive.Linq;

namespace ServerCreation.Engine.Json
{
    public class VersionBuildsPaper
    {
        [JsonProperty("project_id")]
        public string ProjectId { get; set; }

        [JsonProperty("project_name")]
        public string ProjectName { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }

        [JsonProperty("builds")]
        public ObservableCollection<string> Builds { get; set; }
    }
}
