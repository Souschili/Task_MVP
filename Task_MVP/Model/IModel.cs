using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_MVP.Model
{
   public  interface IModel
    {
        IEnumerable<MTask> GetAllProcess();
        IEnumerable<MTask> StopProcess(int index);


    }
}
