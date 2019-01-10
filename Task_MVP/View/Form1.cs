using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using Task_MVP.Model;
using Task_MVP.View;

namespace Task_MVP
{
    public partial class Form1 : Form,IView
    {
        public Form1()
        {
            InitializeComponent();
            //мутим таймер и подписку
            this.timer1.Enabled = true;
            this.timer1.Interval = 500000;//15 секунд
            timer1.Tick += refresh;

        }


        public event EventHandler<EventArgs> ShowProcess;
        public event EventHandler<ModelIntEventArgs> StopProcess;
        public event EventHandler<SendProctssNameEvent> StartProcess;

        // public event Action<int> StopProcess;

        public void ShowAll(IEnumerable<MTask> collect)
        {
            
            //спросить не ломает ли это логику ,в данном случае тут только отображение данных полученых от презентера
          
            foreach (var e in collect)
                this.listBox1.Items.Add(String.Format("{0,-10} {1,25}", e.Id, e.Name));
            this.label6.Text = "Процессов запущенно"+listBox1.Items.Count.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (ShowProcess != null)
                ShowProcess.Invoke(this, e);
        }

        /// <summary>
        /// Обновление списка
        /// </summary>
        /// <param name="s"></param>
        /// <param name="e"></param>
        void refresh(object s,EventArgs e)
        {
           
            ShowProcess?.Invoke(this, e);
        }

        /// <summary>
        /// Убивалка процесса
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            int id = this.listBox1.SelectedIndex;
            StopProcess?.Invoke(this,new ModelIntEventArgs(id));
        }

        /// <summary>
        /// Очистка списка на экране
        /// </summary>
        public void Clear()
        {
            this.listBox1.Items.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string str = this.textBox1.Text;
            StartProcess?.Invoke(this, new SendProctssNameEvent(str));
        }

        public void ShowError(string message)
        {
            MessageBox.Show(message);
        }
    }
}
