namespace ServerCreation.Engine
{
    public class UrlGenerator
    {
        public static string GetPaperDowload(string version, string build)
        {
            return $"https://papermc.io/api/v2/projects/paper/versions/{version}/builds/{build}/downloads/paper-{version}-{build}.jar";
        }
    }
}
