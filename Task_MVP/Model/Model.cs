using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task_MVP.Model
{
    class Model : IModel
    {
        List<MTask> proc { get; set; } 

        /// <summary>
        /// Получаем список всех процессов
        /// </summary>
        /// <returns></returns>
        public IEnumerable<MTask> GetAllProcess()
        {
            proc = new List<MTask>();
            Parallel.Invoke(() =>
            {
                foreach (var e in Process.GetProcesses())
                {
                    proc.Add(new MTask
                    {
                        Id = e.Id,
                        Name = e.ProcessName,
                        Ram = e.WorkingSet64
                    });
                }
            });
            return proc;
        }

        /// <summary>
        /// Убиваем по индексу элемен в колекции,индексы идентичны и списке и на вьюшке
        /// </summary>
        /// <param name="index"></param>
        public IEnumerable<MTask> StopProcess(int index)
        {
           
            var pr = Process.GetProcessById(proc[index].Id);
            Parallel.Invoke(() =>
            {
                proc.RemoveAt(index); //удаляем по индексу убитый процесс
                pr.Kill();
            });
                return proc;
           
        }
    }
}
