using System.Threading.Tasks;

namespace ServerCreation.Engine.FilesManager
{
    public class DowloadSession
    {
        public async Task BeginDownloadTaskAsync(string url, string fileName)
        {
            FileDowloader dowloader = new();

            dowloader.Dowload(url, fileName);

            await Task.CompletedTask;
        }
    }
}
