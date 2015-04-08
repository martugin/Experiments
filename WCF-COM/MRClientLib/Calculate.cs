using System;
using System.ServiceModel;
using MRClientLib.ServiceReference1;

namespace MRClientLib
{
    public class Calculate
    {
        private System.ServiceModel.Channels.Binding binding;// = new WSHttpBinding();
        private EndpointAddress address;// = new EndpointAddress("http://localhost:9000/MRService/");
        public MRClient proxy;

        public Calculate()
        {
            binding = new WSHttpBinding();
            address = new EndpointAddress("http://localhost:9000/MRService/");
            proxy = new MRClient(binding, address);
        }

        public void DownloadAddress(string aS)
        {
            if (aS == "localhost")
            {
                binding = new WSHttpBinding();
                address = new EndpointAddress("http://localhost:9000/MRService/");
            }
            else
            {
                binding = new NetTcpBinding();
                address = new EndpointAddress(aS + "MRService/");
            }

            proxy = new MRClient(binding, address);
        }

        //public void proxyCreate()
        //{
        //    proxy = new MRClient(binding, address);
        //}

        public string Reverse(string a)
        {
            return proxy.Reverse(a);
        }

        public string ToLower(string a)
        {
            return proxy.ToLower(a);
        }
    }
}
