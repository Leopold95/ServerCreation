using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ServerCreation.ViewModels;
using ServerCreationServerSideVisual.Engine.Json;

namespace ServerCreation.Engine.GameServer
{
    public class GameServerReceivedOutoutHandler
    {
        public static void OnNewOutput(string json)
        {
            JsonGameServerOutput serverOutput = JsonConvert.DeserializeObject<JsonGameServerOutput>(json);
            UCLogsViewModel.TextLogs.Value += $"\n{serverOutput.OutputPID} + {serverOutput.Output}";
        }

        public static void OnError(string json)
        {
            JsonGameServerError serverError = JsonConvert.DeserializeObject<JsonGameServerError>(json);
            UCLogsViewModel.TextLogs.Value += $"\n{serverError.ProcessID} + {serverError.Error}";
        }

        public static void OnException(string json)
        {
            JsonGameServerException serverException = JsonConvert.DeserializeObject<JsonGameServerException>(json);
            UCLogsViewModel.TextLogs.Value += $"\n{serverException.ProcessID} + {serverException.Exception}";
        }
    }
}
