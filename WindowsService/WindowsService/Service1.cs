using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.ServiceProcess;
using System.Text;
using System.IO;


namespace WindowsService
{
    public partial class AAAProba : ServiceBase
    {
        public AAAProba()
        {
            InitializeComponent();
        }

        //Определяем таймер
        private System.Timers.Timer timer1;

        protected override void OnStart(string[] args)
        {
            FileStream fs = new FileStream(@"c:\a. txt" , FileMode.Append, FileAccess.Write);
            StreamWriter SR = new StreamWriter(fs);
            SR.WriteLine("Поехали");
            SR.Flush();
            SR.Close();
            //Создаем таймер и выставляем его параметры
            this.timer1 = new System.Timers.Timer();
            this.timer1.Enabled = true;
            this.timer1.Interval = 500;
            this.timer1.Elapsed +=
             new System.Timers.ElapsedEventHandler(this.timer1_Elapsed);
            this.timer1.AutoReset = true;
            this.timer1.Start();

        }

        protected override void OnStop()
        {
            FileStream fs = new FileStream(@"c:\a. txt", FileMode.Append, FileAccess.Write);
            StreamWriter SR = new StreamWriter(fs);
            SR.WriteLine("Встали");
            SR.Flush();
            SR.Close(); 
        }

        private void timer1_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            //Записываем время в файл или делаем все, что хотим
            FileStream fs = new FileStream(@"c:\a. txt", FileMode.Append, FileAccess.Write);
            StreamWriter SR = new StreamWriter(fs);
            SR.WriteLine(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss"));
            SR.Flush();
            SR.Close(); 
        }

    }

    
}
