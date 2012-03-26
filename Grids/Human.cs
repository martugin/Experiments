using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;

namespace Grids
{
    public class Human
    {
        private ObservableCollection<Human>_children;
        public ObservableCollection<Human> Children
        {
            get { return _children; }
            set
            {
                if (value == _children) return;
                _children = value;
                RaisePropertyChanged("Children");
            }
        }
        
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

        public Human ()
        {
            Name = null;
            Age = 0;
            Married = false;
            Children = null;
        }

        public Human(string name, int age, bool married, ObservableCollection<Human> children)
        {
            Name = name;
            Age = age;
            Married = married;
            Children = children;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class HumanList : ObservableCollection<Human>, IEditableObject
    {
        public HumanList()
        {
            Init();
        }

        private void Init()
        {
            Add(new Human("Вася", 20, false, new ObservableCollection<Human>{new Human("Коля", 5, false, null)}));
            Add(new Human("Маша", 20, false, null));
            Add(new Human("Витя", 40, true, new ObservableCollection<Human> {new Human("Оля", 3, false, null), new Human("Валя", 6, false, null)}));
        }

        public void Message()
        {
            foreach(var h in this)
            {
                MessageBox.Show(h.Name + "; " + h.Clicuha + "; " + h.Age + "; " + h.Married);
            }
        }

        public void BeginEdit()
        {
            throw new NotImplementedException();
        }

        public void EndEdit()
        {
            throw new NotImplementedException();
        }

        public void CancelEdit()
        {
            throw new NotImplementedException();
        }
    }
}
