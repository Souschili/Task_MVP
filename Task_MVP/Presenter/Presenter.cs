using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Task_MVP.Model;
using Task_MVP.View;

namespace Task_MVP.Presenter
{
    class Presenter
    {
        IModel model;
        IView view;

        public object Paralel { get; private set; }

        public Presenter(IModel model, IView view)
        {
            this.model = model;
            this.view = view;

            //подписка на эвент 
            view.ShowProcess += ShowAllProcess;
            view.StopProcess += Stop_Process;
            view.StartProcess += Start_Process;
        }
        /// <summary>
        /// Запуск процесса 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Start_Process(object sender, SendProctssNameEvent e)
        {
            try
            {
                if (e.ProcessName != null)
                    Process.Start(e.ProcessName);
                var p = model.GetAllProcess();
                view.ShowAll(p);
                
            }
            catch(Exception ex)
            {
                view.ShowError(ex.Message+" "+e.ProcessName);
            }

            
        }

        /// <summary>
        /// Убить процесс
        /// </summary>
        /// <param name="obj"></param>
        private void Stop_Process(object s,ModelIntEventArgs e)
        {
            
            var col=model.StopProcess(e.id);
            view.Clear();
            
            view.ShowAll(col);
            
           
        }

        /// <summary>
        /// Вывод всех проектов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowAllProcess(object sender, EventArgs e)
        {
           //получаем коллекцию и передаем для отображения
            var tasks = model.GetAllProcess();
            view.Clear();
            view.ShowAll(tasks);
        }
    }
}
