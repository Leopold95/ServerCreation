using Reactive.Bindings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerCreation.ViewModels
{
    public class UCLogsViewModel
    {
        public ReactiveProperty<string> TextLogs { get; set; } = new();
    }
}
