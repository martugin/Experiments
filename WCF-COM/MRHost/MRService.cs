using System;
using System.ServiceModel;

namespace MRHost
{
    [ServiceContract]
    public interface IMR
    {
        [OperationContract]
        string Reverse(string xS);

        [OperationContract]
        string ToLower(string xS);
    }

    class MRService:IMR
    {
        public MRService(){}

        public string Reverse(string xS)
        {
            string tempS = "";
            for (int i = xS.Length - 1; i >= 0; i--) tempS += xS[i];
            return tempS;
        }

        public string ToLower(string xS)
        {
            return xS.ToLower();
        }
    }
}
