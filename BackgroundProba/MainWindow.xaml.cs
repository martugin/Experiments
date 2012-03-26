using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BackgroundProba
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private readonly BackgroundWorker bw = new BackgroundWorker();


        private void butStart_Click(object sender, RoutedEventArgs e)
        {
            flag = false;
            bw.WorkerReportsProgress = true;
            bw.WorkerSupportsCancellation = true;
            bw.DoWork += OnDoWork;
            bw.ProgressChanged += OnProgressChnged;
            bw.RunWorkerCompleted += OnRunWorkerCompleted;
            bw.RunWorkerAsync();
            //Thread.Sleep(2000);
        }

        private void OnDoWork(object sender, DoWorkEventArgs e)
        {
            for(int i=1; i<=10; i++)
            {
                Thread.Sleep(500);
                bw.ReportProgress(i*10, (i*10).ToString());
                if (flag)
                {
                    e.Cancel = true;
                    return;
                }
            }
        }

        private void OnProgressChnged(object sender, ProgressChangedEventArgs e)
        {
            Tablo.Text = e.UserState.ToString();
            Status.Value = e.ProgressPercentage;
        }

        private void OnRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Tablo.Text = "все";
        }

        private bool flag;

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            flag = true;
        }
    }
}
