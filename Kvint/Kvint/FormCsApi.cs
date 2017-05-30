using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Kvint
{
    public partial class FormCsApi : Form
    {
        public FormCsApi()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Init: " + CsApi.Init());
            MessageBox.Show("Версия: " + CsApi.GetKvintVersion().ToString("x"));
            CsApi.Done();
        }

        private void butParam_Click(object sender, EventArgs e)
        {
            var h = CsApi.OpenParamById(Convert.ToInt32(CardId.Text), Convert.ToInt32(ParamNo.Text ?? "0"), 0);
            MessageBox.Show("Handler по Id: " + h);
            var hs = CsApi.OpenParamByName(Marka.Text, ParamName.Text, 0);
            MessageBox.Show("Handler по Marka: " + hs);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //var h = CsApi.OpenParamById(Convert.ToInt32(CardId.Text), Convert.ToInt32(ParamNo.Text ?? "0"), 0x1015);
            var h = CsApi.OpenParamById(Convert.ToInt32(CardId.Text), 0, 0);
            //var h = CsApi.OpenParamExternal(Convert.ToInt32(CardId.Text), Convert.ToInt32(ParamNo.Text ?? "0"), ServerName.Text, 0);
            MessageBox.Show("Handler по Id: " + h);
            CsData m = new CsData();
            var d = CsApi.TimeToKvint(Convert.ToDateTime(TimeBegin.Text));
            MessageBox.Show(d + "\n" + CsApi.GetTime());
            try
            {
                MessageBox.Show("Поиск: " + CsApi.FindFirst(h, ref m, CsApi.TimeToKvint(Convert.ToDateTime(TimeBegin.Text))));
                MessageBox.Show(m.Time + " - " + m.Value + " - " + m.ErrorCode);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + ex.StackTrace);
            }

            try
            {
                MessageBox.Show("Значение: " + CsApi.ReadData(h, ref m));
                MessageBox.Show(m.Time + " - " + m.Value + " - " + m.ErrorCode);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + ex.StackTrace);
            }

            try
            {
                MessageBox.Show("Следующее: " + CsApi.FindNext(h, ref m));
                MessageBox.Show(m.Time + " - " + m.Value + " - " + m.ErrorCode);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + ex.StackTrace);
            }
        }

        private void butTime_Click(object sender, EventArgs e)
        {
            var d = CsApi.GetTime();
            MessageBox.Show(d.ToString());
            string s = "";
            CsApi.TimeToString(s, 18, d);
            MessageBox.Show(s);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var h = CsApi.OpenParamExternal(Convert.ToInt32(CardId.Text), Convert.ToInt32(ParamNo.Text ?? "0"), ServerName.Text, 0x1015);
            MessageBox.Show("Handler по Id: " + h);
        }

        private void butNext_Click(object sender, EventArgs e)
        {

        }
    }
}
