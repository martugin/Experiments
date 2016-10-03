using System;
using System.ServiceModel;
using MRClientLib.ServiceReference1;

namespace MRClientLib
{
    public class Calculate
    {
        private System.ServiceModel.Channels.Binding _binding;// = new WSHttpBinding();
        private EndpointAddress _address;// = new EndpointAddress("http://localhost:9000/MRService/");
        public MRClient Proxy;

        public Calculate()
        {
            _binding = new WSHttpBinding();
            _address = new EndpointAddress("http://localhost:9000/MRService/");
            Proxy = new MRClient(_binding, _address);
        }

        public void DownloadAddress(string aS)
        {
            if (aS == "localhost")
            {
                _binding = new WSHttpBinding();
                _address = new EndpointAddress("http://localhost:9000/MRService/");
            }
            else
            {
                _binding = new NetTcpBinding();
                _address = new EndpointAddress(aS + "MRService/");
            }

            Proxy = new MRClient(_binding, _address);
        }

        //public void proxyCreate()
        //{
        //    Proxy = new MRClient(_binding, _address);
        //}

        public string Reverse(string a)
        {
            return Proxy.Reverse(a);
        }

        public string ToLower(string a)
        {
            return Proxy.ToLower(a);
        }
    }
}
