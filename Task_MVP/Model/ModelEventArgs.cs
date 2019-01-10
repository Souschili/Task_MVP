using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_MVP.Model
{
   public class ModelIntEventArgs:EventArgs
    {
        public ModelIntEventArgs(int id)
        {
            this.id = id;
        }

        public int id { get; private set; }


    }
}
