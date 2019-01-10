using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_MVP.Model;

namespace Task_MVP.View
{
    interface IView
    {
        void ShowAll(IEnumerable<MTask> collect);
        void ShowError(string message);
       

        void Clear();
        event EventHandler<EventArgs> ShowProcess;
        event EventHandler<ModelIntEventArgs> StopProcess;
        event EventHandler<SendProctssNameEvent> StartProcess;


       // event Action<int> StopProcess;
    }
}
