using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reactive.Linq;
using Avalonia;
using Newtonsoft.Json;
using ServerCreation.Engine.Json;

namespace ServerCreation.Engine
{
    public class JsonParser
    {
        public ObservableCollection<string> GetPaperVersionList()
        {
            var coll = new ObservableCollection<string>();

            string url = Constans.PaperVersionListUrl;

            //TODO creatwe web helper class for getting url
            WebClient client = new();
            string json = client.DownloadString(url);

            var model = JsonConvert.DeserializeObject<VersionListPaperModel>(json);

            foreach (var item in model.Versions)
                coll.Add(item);

            return coll;
        }

        public string GetLastVersionBuild(string version)
        {
            string? s;

            string url = Constans.PaperVersionBuildsUrl(version);

            //TODO creatwe web helper class for getting url
            WebClient client = new();
            string json = client.DownloadString(url);

            var model = JsonConvert.DeserializeObject<VersionBuildsPaper>(json);

            return model.Builds.Last().ToString();
        }

        public ObservableCollection<string> GetLastVersionBuilds(string version)
        {
            string? s;

            string url = Constans.PaperVersionBuildsUrl(version);

            //TODO creatwe web helper class for getting url
            WebClient client = new();
            string json = client.DownloadString(url);

            var model = JsonConvert.DeserializeObject<VersionBuildsPaper>(json);

            return model.Builds;
        }
    }
}
