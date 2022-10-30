namespace ServerCreation.Engine
{
    public class UrlGenerator
    {
        public static string PaperDowload(string version, string build) =>
            $"https://papermc.io/api/v2/projects/paper/versions/{version}/builds/{build}/downloads/paper-{version}-{build}.jar";
    }
}
