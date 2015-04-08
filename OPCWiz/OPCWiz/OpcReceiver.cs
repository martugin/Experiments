using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using BaseLibrary;
using CommonTypes;
using OPCAutomation;

namespace OPCWiz
{
    public class OPCReceiver : IReceiver
    {
        public OPCReceiver(string name)
        {
            Name = name;
        }

        //Тип провайдера
        public ProviderType Type { get { return ProviderType.Receiver; } }
        //Код провайдера
        public string Code { get { return "OPCReceiver"; } }
        //Имя провайдера
        public string Name { get; set; }
        //Настройки провайдера
        public string Inf { get; internal set; }
        //Тип настройки
        internal ProviderSetupType SetupType { get; private set; }

        //True, пока идет настройка
        internal bool IsSetup { get; set; }

        public string Setup(string inf, ProviderSetupType setupType)
        {
            try {_opc.Disconnect();} catch {}
            Inf = inf;
            SetupType = setupType;
            IsSetup = true;
            //var setup = new Form1 { Provider = this };
            //setup.ShowDialog();
            while (IsSetup) Thread.Sleep(500);
            return Inf;
        }

        //Соединение с OPC-сервером
        private OPCServer _opc;

        public void Connect(string inf, ProviderSetupType setupType, Command command, bool isRepeat = false)
        {
            try { _opc.Disconnect(); Thread.Sleep(500);} catch { }
            try
            {
                var dic = inf.ToPropertyDictionary();
                var server = new OPCServer();
                if (!dic.ContainsKey("Node") || dic["Node"] == "") server.Connect(dic["OPCServerName"]);
                else server.Connect(dic["OPCServerName"], dic["Node"]);
            }
            catch(Exception ex)
            {
                command.AddError("Ошибка соединения с OPC-сервером", ex);
            }
        }

        public void Prepare(Command command, bool isRepeat = false)
        {
            throw new NotImplementedException();
        }

        public List<IProviderItem> Objects
        {
            get { throw new NotImplementedException(); }
        }

        public IProviderItem AddObject(string objectInf, string code)
        {
            throw new NotImplementedException();
        }

        public void WriteValues(Command command, bool isRepeat = false)
        {
            throw new NotImplementedException();
        }
    }
}
