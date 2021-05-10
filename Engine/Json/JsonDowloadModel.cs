using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerCreation.Engine
{
    public class JsonDowloadModel
    {
        public string Speed { get; set; } = String.Empty;
        public string Progress { get; set; } = String.Empty;
        public string Recieved { get; set; } = String.Empty;
        public string TotalToRecirve { get; set; } = String.Empty;
    }
}
