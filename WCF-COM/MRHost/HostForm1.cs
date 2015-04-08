using System;
using System.Net.NetworkInformation;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Windows.Forms;
using System.Drawing;

namespace MRHost
{
    public partial class HostForm1 : Form
    {
        public ServiceHost host;
        private WSHttpBinding wsBinding;
        private NetTcpBinding tcpBinding;

        public HostForm1()
        {
            InitializeComponent();

            //NetworkInterface[] nis = System.Net.NetworkInformation.NetworkInterface.GetAllNetworkInterfaces();
            //foreach (NetworkInterface ni in nis)
            //{
            //    IPInterfaceProperties ipip = ni.GetIPProperties();
            //    foreach (UnicastIPAddressInformation uipai in ipip.UnicastAddresses)
            //        {
            //            MessageBox.Show(uipai.Address.ToString());
            //        }
            //}

            //Формируем хост, указывая сервис и базовые адреса
            Uri httpBaseAddress = new Uri("http://localhost:9000/MRService");
            Uri tcpBaseAddress = new Uri("net.tcp://localhost:9010/MRService");
            host = new ServiceHost(typeof(MRService), httpBaseAddress, tcpBaseAddress);

            //Настраиваем MEX
            ServiceMetadataBehavior metadataBehavior;
            metadataBehavior = host.Description.Behaviors.Find<ServiceMetadataBehavior>();
            if (metadataBehavior == null)
            {
                metadataBehavior = new ServiceMetadataBehavior();
                metadataBehavior.HttpGetEnabled = true;
                host.Description.Behaviors.Add(metadataBehavior);
            }

            //Добавляем конечные точки
            wsBinding = new WSHttpBinding();
            tcpBinding = new NetTcpBinding();
            host.AddServiceEndpoint(typeof(IMetadataExchange), tcpBinding, "MEX");
            host.AddServiceEndpoint(typeof(IMR), wsBinding, "");
            host.AddServiceEndpoint(typeof (IMR), tcpBinding, "");
        }

        //Открываем хост
        private string st;
        private void button1_Click(object sender, EventArgs e)
        {
            host.Open();
            label1.BackColor = Color.DeepSkyBlue;
            label1.Text = "Хост запущен";
            foreach (var s in host.Description.Endpoints)
            {
                st += s.Address + "\n";
                st += s.Binding + "\n";
                st += s.Contract.Name + "\n";
            }
            MessageBox.Show(st);
        }
    }
}
