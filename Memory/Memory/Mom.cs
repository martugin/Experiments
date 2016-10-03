using System;
using System.Collections.Generic;

namespace Memory
{
    public class Mom
    {
        public Mom(DateTime time, double mean, int err = 0)
        {
            Time = time;
            Mean = mean;
            Err = err;
        }

        public DateTime Time { get; private set; }
        public double Mean { get; private set; }
        public int Err { get; private set; }
    }

    public class MomList
    {
        private readonly List<Mom> _list = new List<Mom>();
        public List<Mom> List { get { return _list; } }
    }
}