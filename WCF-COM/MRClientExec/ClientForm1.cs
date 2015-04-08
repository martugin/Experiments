using System;
using System.ServiceModel;
using System.Windows.Forms;
using MRClientExec.ServiceReference1;

namespace MRClientExec
{
    public partial class ClientForm1 : Form
    {
        public ClientForm1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Создаем пустую привязку и адрес конечной точки для формирования экземпляра клиента
            System.ServiceModel.Channels.Binding binding = null;
            EndpointAddress endpointAddress = null;

            //выбираем привязку и адрес конечной точки
            switch (radioButton1.Checked)
            {
                case true:
                    binding = new WSHttpBinding();
                    endpointAddress = new EndpointAddress("http://localhost:9000/MRService/");
                    break;
                case false:
                    binding = new NetTcpBinding();
                    endpointAddress = new EndpointAddress(textBox1.Text+@"/MRService/");//"net.tcp://localhost:9010/MRService/");
                    break;
            }

            //создаем экземпляр класса Client
            MRClient proxy = new MRClient(binding, endpointAddress);
            switch (comboBox1.Text)
            {
                case "Реверс":
                    textBox3.Text = proxy.Reverse(textBox2.Text);
                    break;
                case "В нижний регистр":
                    textBox3.Text = proxy.ToLower(textBox2.Text);
                    break;
            }

            string st = "";
            st += proxy.Endpoint.Address + "\n";
            st += proxy.Endpoint.Binding + "\n";
            st += proxy.Endpoint.Contract.Name + "\n";
            MessageBox.Show(st);

            proxy.Close();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Text = "localhost";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Text = "net.tcp://localhost:9010";
        }
    }
}
