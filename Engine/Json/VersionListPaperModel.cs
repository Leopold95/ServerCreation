using Newtonsoft.Json;
using System.Collections.Generic;

namespace ServerCreation.Engine.Json
{
    public class VersionListPaperModel
    {
        [JsonProperty("project_id")]
        public string ProjectId { get; set; }

        [JsonProperty("project_name")]
        public string ProjectName { get; set; }

        [JsonProperty("version_groups")]
        public List<string> VersionGroups { get; set; } = new();

        [JsonProperty("versions")]
        public List<string> Versions { get; set; } = new();
    }
}
