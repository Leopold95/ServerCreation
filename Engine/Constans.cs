using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerCreation.Engine
{
    static class Constans
    {
        public static readonly string PaperVersionListUrl = "https://papermc.io/api/v2/projects/paper";

        public static string PaperVersionBuildsUrl(string version) => $"https://papermc.io/api/v2/projects/paper/versions/{version}";
    }
}
