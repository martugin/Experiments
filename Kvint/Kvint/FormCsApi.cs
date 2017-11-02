using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Kvint
{
    public partial class FormCsApi : Form
    {
        public FormCsApi()
        {
            InitializeComponent();
        }

        private int _handler;

        private void AddLog(string s)
        {
            Log.Text += Environment.NewLine + s;
        }

        private void LogData(CsData m)
        {
            var t = CsApi.KvintToTime(m.Time);
            AddLog(t + "," + t.Millisecond.ToString("000") + " - " + m.Value + " - " + m.ErrorCode);
        }

        private void butParam_Click(object sender, EventArgs e)
        {
            Log.Text = "Init: " + CsApi.Init();
            if (radioId.Checked)
            {
                _handler = CsApi.OpenParamById(Convert.ToInt32(CardId.Text),
                                                                   string.IsNullOrEmpty(ParamNo.Text) ? 0 : Convert.ToInt32(ParamNo.Text),
                                                                   Convert.ToInt32(Flags.Text));
                _handler = CsApi.OpenParamById(Convert.ToInt32(CardId.Text), 
                                                                   string.IsNullOrEmpty(ParamNo.Text) ? 0 : Convert.ToInt32(ParamNo.Text), 
                                                                   Convert.ToInt32(Flags.Text));
                AddLog("Handler по Id: " + _handler);
            }
            if (radioExternal.Checked)
            {
                _handler = CsApi.OpenParamExternal(Convert.ToInt32(CardId.Text),
                                                                        string.IsNullOrEmpty(ParamNo.Text) ? 0 : Convert.ToInt32(ParamNo.Text),
                                                                        ServerName.Text,
                                                                        Convert.ToInt32(Flags.Text));
                _handler = CsApi.OpenParamExternal(Convert.ToInt32(CardId.Text),
                                                                        string.IsNullOrEmpty(ParamNo.Text) ? 0 : Convert.ToInt32(ParamNo.Text),
                                                                        ServerName.Text,
                                                                        Convert.ToInt32(Flags.Text));
                AddLog("Handler External: " + _handler);    
            }
            if (radioMarka.Checked)
            {
                _handler = CsApi.OpenParamByName(Marka.Text, ParamName.Text, Convert.ToInt32(Flags.Text));
                _handler = CsApi.OpenParamByName(Marka.Text, ParamName.Text, Convert.ToInt32(Flags.Text));
                AddLog("Handler по марке: " + _handler);
            }
        }

        private void butFirst_Click(object sender, EventArgs e)
        {
            try
            {
                CsData m = new CsData();
                var d = CsApi.TimeToKvint(Convert.ToDateTime(TimeBegin.Text));
                AddLog("Время: " + d);
                AddLog("FindFirst: " + CsApi.FindFirst(_handler, ref m, d));
                LogData(m);
            }
            catch (Exception ex)
            {
               AddLog(ex.Message);
            }
        }

        private void butRead_Click(object sender, EventArgs e)
        {
            try
            {
                CsData m = new CsData();
                AddLog("ReadData: " + CsApi.ReadData(_handler, ref m));
                LogData(m);
            }
            catch (Exception ex)
            {
                AddLog(ex.Message);
            }
        }

        private void butNext_Click(object sender, EventArgs e)
        {
            try
            {
                CsData m = new CsData();
                AddLog("FindNext: " + CsApi.FindNext(_handler, ref m));
                LogData(m);
            }
            catch (Exception ex)
            {
                AddLog(ex.Message);
            }
        }

        private void butClose_Click(object sender, EventArgs e)
        {
            CsApi.Done();
            AddLog("Закрытие");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddLog("Версия: " + CsApi.GetKvintVersion().ToString("x"));
        }

        private void FormCsApi_FormClosing(object sender, FormClosingEventArgs e)
        {
            CsApi.Done();
        }

        private void butList_Click(object sender, EventArgs e)
        {
            CsData m = new CsData();
            var d = CsApi.TimeToKvint(Convert.ToDateTime(TimeBegin.Text));
            CsApi.FindFirst(_handler, ref m, d);
            int n = 1;
            var t = DateTime.Now;
            while (CsApi.FindNext(_handler, ref m))
                n++;
            AddLog("Прочитано " + n + " значений");
            AddLog(DateTime.Now.Subtract(t).TotalMilliseconds + " мс");
        }
    }
}
