using System;
using System.Threading;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Threading;
using CommonTypes;
using Application = System.Windows.Application;
using MessageBox = System.Windows.MessageBox;
using MouseEventArgs = System.Windows.Forms.MouseEventArgs;

namespace Controller
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            bool isHiden = e.Args.Length >= 1 && e.Args[0] == @"\h";
            bool wasMain = false , wasHiden = false;
            try
            {
                Mutex.OpenExisting("InfoTask.Controller.Main");
                wasMain = true;
            }
            catch {}
            try
            {
                Mutex.OpenExisting("InfoTask.Controller.Hiden");
                wasHiden = true;
            }
            catch {}
            if (wasMain || (isHiden && wasHiden))//Уже открыт какой надо
                Current.Shutdown();
            else
            {
                if (!wasHiden) //Никакой не открыт
                {
                    General.Mutex = new Mutex(false, "InfoTask.Controller." + (isHiden ? "Hiden" : "Main")); 
                    if (isHiden)
                    {
                        var task = new Thread(ListenMutex) { IsBackground = true, Priority = ThreadPriority.Lowest };
                        task.SetApartmentState(ApartmentState.STA);
                        task.Start();
                    }
                    General.Initialize(isHiden);
                }
                else //Открыт Hiden, надо Main
                {
                    General.Mutex = new Mutex(false, "InfoTask.Controller.Open");
                    while (true)
                    {
                        try
                        {
                            Mutex.OpenExisting("InfoTask.Controller.Main");
                            General.Mutex.Close();
                            General.Mutex.Dispose();
                            Current.Shutdown();
                            return;
                        }
                        catch { Thread.Sleep(50); }
                    }
                }
            }
        }
        
        //Запускается фоновым потоком, проверяет наличие мьютексов - комманд (Open)
        private static void ListenMutex()
        {
            while (true)
            {
                try
                {
                    Mutex.OpenExisting("InfoTask.Controller.Open");
                    General.Mutex.Close();
                    General.Mutex.Dispose();
                    General.OpenWindow(false);
                }
                catch { }
                Thread.Sleep(100);
            }
        }
    }
}

