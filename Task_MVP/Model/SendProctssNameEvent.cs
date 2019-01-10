using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_MVP.Model
{
   public  class SendProctssNameEvent:EventArgs
    {
        public SendProctssNameEvent(string processName)
        {
            ProcessName = processName;
        }

        public string ProcessName { get; private set; }
    }
}
