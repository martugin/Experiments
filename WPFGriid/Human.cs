using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace WPFGriid
{
    public class Human : INotifyPropertyChanged
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                if (value == _name) return;
                _name = value;
                RaisePropertyChanged("Name");
            }
        }

        public string Clicuha
        {
            get { return _name; }
        }

        private int _age;
        public int Age
        {
            get { return _age; }
            set
            {
                if (_age == value) return;
                _age = value;
                RaisePropertyChanged("Age");
            }
        }
        
        private bool _married;
        public bool Married
        {
            get { return _married; }
            set
            {
                if (value == _married) return;
                _married = value;
                RaisePropertyChanged("Married");
            }
        }

        public Human(string name, int age, bool married)
        {
            Name = name;
            Age = age;
            Married = married;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
