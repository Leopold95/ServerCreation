using System.Collections.ObjectModel;
using System.Net;
using Newtonsoft.Json;
using ServerCreation.Engine.Json;

namespace ServerCreation.Engine
{
    public class JsonParser
    {
        public ObservableCollection<string> GetPaperVersionList()
        {
            var coll = new ObservableCollection<string>();

            string url = @"https://papermc.io/api/v2/projects/paper";

            WebClient client = new();
            string json = client.DownloadString(url);

            var model = JsonConvert.DeserializeObject<VersionListPaperModel>(json);

            foreach (var item in model.Versions)
                coll.Add(item);

            return coll;
        }
    }
}
