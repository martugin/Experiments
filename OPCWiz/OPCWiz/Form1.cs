using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using BaseLibrary;
using OPCAutomation;
using System.Runtime.InteropServices;
using System.Reflection;

namespace OPCWiz
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //Ссылка на провайдер
        //private OPCReceiver _provider;
        //internal OPCReceiver Provider
        //{
        //    get { return _provider; }
        //    set
        //    {
        //        _provider = value;
        //        var dic = value.Inf.ToPropertyDictionary();
        //        OPCServerName.Text = dic.Get("OPCServerName");
        //        Node.Text = dic.Get("Node");
        //    }
        //}

        //True, если нажата OK, false, если Cancel
        private bool _isOk;

        private void butOK_Click(object sender, EventArgs e)
        {
            _isOk = true;
            Close();
        }

        private void butCancel_Click(object sender, EventArgs e)
        {
            _isOk = false;
            Close();
        }

        private void SetupForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (_isOk)
            //{
            //    Provider.Inf = (new Dictionary<string, string>
            //    {
            //        {"OPCServerName", OPCServerName.Text ?? "" }, 
            //        {"Node", Node.Text ?? "" }
            //    }).ToPropertyString();
            //}
            //Provider.IsSetup = false;
        }

        private void butCheck_Click(object sender, EventArgs e)
        {
            bool no = false;
            Exception exep = null;
            try
            {
                var server = new OPCServer();
                if (string.IsNullOrEmpty(Node.Text)) server.Connect(OPCServerName.Text);
                else server.Connect(OPCServerName.Text, Node.Text);
                if (server.ServerState != 1) no = true;
                else
                {
                    MessageBox.Show("Успешное соединение. " + server.ServerName + ", " + server.ServerNode + ", состояние:" + server.ServerState);
                }
                server.Disconnect();
            }
            catch (Exception ex)
            {
                exep = ex;
                no = true;
            }
            if (no)
            {
                if (exep == null) MessageBox.Show("Соединение не установлено");
                else MessageBox.Show("Соединение не установлено \n" + exep.Message + "\n" + exep.StackTrace);
            }
        }

        [ComVisible(true)]
        private void butCheckRec_Click(object sender, EventArgs e)
        {
            try
            {
                var server = new OPCServer();
                if (string.IsNullOrEmpty(Node.Text)) server.Connect(OPCServerName.Text);
                else server.Connect(OPCServerName.Text, Node.Text);
                var group = server.OPCGroups.Add("Gr1");
                group.IsSubscribed = true;
                group.UpdateRate = 1000;
                group.IsActive = true;
                group.DeadBand = 0;
                int n = 4;
                if (PointTag4.Text == "") n = 3;
                if (PointTag3.Text == "") n = 2;
                if (PointTag2.Text == "") n = 1;
                if (PointTag1.Text == "") n = 0;
                Array handlesArr = Array.CreateInstance(typeof (Int32), n + 1);
                var itemArr = Array.CreateInstance(typeof(string), n + 1);
                Array errorsArr = new object[n + 1];
                Array valuesArr = new object[n + 1];

                itemArr.SetValue(PointTag1.Text, 0);
                for (int i = 0; i < n + 1; i++)
                {
                    handlesArr.SetValue(i, i);
                }

                switch (n)
                {
                    case 4:
                        itemArr.SetValue(PointTag1.Text, 1);
                        itemArr.SetValue(PointTag2.Text, 2);
                        itemArr.SetValue(PointTag3.Text, 3);
                        itemArr.SetValue(PointTag4.Text, 4);
                        SetValue(PointType1.Text, PointValue1.Text, 1, valuesArr);
                        SetValue(PointType2.Text, PointValue2.Text, 2, valuesArr);
                        SetValue(PointType3.Text, PointValue3.Text, 3, valuesArr);
                        SetValue(PointType4.Text, PointValue4.Text, 4, valuesArr);
                        break;
                    case 3:
                        itemArr.SetValue(PointTag1.Text, 1);
                        itemArr.SetValue(PointTag2.Text, 2);
                        itemArr.SetValue(PointTag3.Text, 3);
                        SetValue(PointType1.Text, PointValue1.Text, 1, valuesArr);
                        SetValue(PointType2.Text, PointValue2.Text, 2, valuesArr);
                        SetValue(PointType3.Text, PointValue3.Text, 3, valuesArr);
                        break;
                    case 2:
                        itemArr.SetValue(PointTag1.Text, 1);
                        itemArr.SetValue(PointTag2.Text, 2);
                        SetValue(PointType1.Text, PointValue1.Text, 1, valuesArr);
                        SetValue(PointType2.Text, PointValue2.Text, 2, valuesArr);
                        break;
                    case 1:
                        itemArr.SetValue(PointTag1.Text, 1);
                        SetValue(PointType1.Text, PointValue1.Text, 1, valuesArr);
                        break;
                }
                
                    //itemArr.SetValue("Bucket Brigade.try3" + i, i);
                Array serverHandles = new object[n + 1];
                
                group.OPCItems.AddItems(n, ref itemArr, ref handlesArr, out serverHandles, out errorsArr);
                group.SyncWrite(n, ref serverHandles, ref valuesArr, out errorsArr);
                //group.OPCItems.Remove(n, ref handlesArr, out errorsArr);

                if (server.OPCGroups.Count > 0) server.OPCGroups.RemoveAll();
                server.Disconnect();
                MessageBox.Show("Значение успешо записано");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при записи значения. " + ex.Message + "\n" + ex.StackTrace);
            }
        }

        private void SetValue(string pointType, string pointValue, int number, Array valuesArr)
        {
            switch (pointType)
            {
                case "Bool":
                    valuesArr.SetValue(pointValue == "1", number);
                    break;
                case "Int32":
                    valuesArr.SetValue(int.Parse(pointValue), number);
                    break;
                case "Int8":
                    valuesArr.SetValue(byte.Parse(pointValue), number);
                    break;
                case "Int16":
                    valuesArr.SetValue(Int16.Parse(pointValue), number);
                    break;
                case "UInt16":
                    valuesArr.SetValue(UInt16.Parse(pointValue), number);
                    break;
                case "Float":
                    valuesArr.SetValue(float.Parse(pointValue), number);
                    break;
                case "Double":
                    valuesArr.SetValue(double.Parse(pointValue), number);
                    break;
            }
        }
    }
}
