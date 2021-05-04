using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerCreation.Engine
{
    public class JsonDowloadModel
    {
        public string Speed { get; set; }
        public string Progress { get; set; }
        public string Recieved { get; set; }
        public string TotalToRecirve { get; set; }
    }
}
