using ServerCreation.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerCreation.Engine
{
    public class ServersRemouter
    {
        public static int PID { get; set; }
        public static StreamWriter streamWr { get; set; }

        public void StartServer()
        {
            
            var jarFile = "C:\\Users\\Leopo\\source\\repos\\ServerCreation\\bin\\Debug\\net5.0\\server.jar";

            // location of the java.exe binary used to start the jar file
            var javaExecutable = "C:\\Program Files\\Java\\jre1.8.0_281\\bin\\java.exe";

            try
            {
                Process process = new Process();
                ProcessStartInfo processStartInfo = new ProcessStartInfo(javaExecutable, $"java -jar {jarFile} nogui");

                process.StartInfo = processStartInfo;
                process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                process.StartInfo.CreateNoWindow = true;
                process.StartInfo.UseShellExecute = false;

                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.RedirectStandardInput = true;
                process.StartInfo.RedirectStandardError = true;

                process.OutputDataReceived += p_OutputDataReceived;
                process.ErrorDataReceived += p_ErrorDataRecived;

                process.Start();

                process.BeginOutputReadLine();
                process.BeginErrorReadLine();

                streamWr.AutoFlush = true;
                streamWr = process.StandardInput;

                PID = process.Id;

                void p_OutputDataReceived(object sender, DataReceivedEventArgs e) => USServerStarterViewModel.TextIn.Value += $"\n{e.Data}";
                void p_ErrorDataRecived(object sender, DataReceivedEventArgs e) => USServerStarterViewModel.TextIn.Value += $"\n{e.Data}";
            }
            catch (Exception exception)
            {
                USServerStarterViewModel.TextIn.Value = exception.Message;
            }
        }
    }
}
