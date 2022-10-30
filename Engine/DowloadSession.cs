using System.Threading.Tasks;

namespace ServerCreation.Engine
{
    public class DowloadSession
    {
        public async Task BeginDownload()
        {
            FileDowloader dowloader = new();



            await Task.CompletedTask;
        }
    }
}
