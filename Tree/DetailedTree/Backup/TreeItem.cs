using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Threading;
using System.Diagnostics;
using System.Collections.ObjectModel;

namespace DetailedTree
{
    public class TreeItem : INotifyPropertyChanged, IEnumerable<TreeItem>
    {
        private string _title;
        private string _comments;
        private string _timeModified;
        private ObservableCollection<TreeItem> _children = new ObservableCollection<TreeItem>();

        public string Title
        {
            get { return _title; }
            set { _title = value; OnPropertyChanged(); }
        }
        
        public string DateTime
        {
            get { return _timeModified; }
            set { _timeModified = value; OnPropertyChanged(); }
        }
        
        public string Raiting
        {
            get { return _comments; }
            set { _comments = value; OnPropertyChanged(); }
        }
        
        public ObservableCollection<TreeItem> Children
        {
          get { return _children; }
          set { _children = value; OnPropertyChanged(); }
        }

        public override string ToString()
        {
            return Title;
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged()
        {
            if (PropertyChanged != null)
            {
                try
                {
                    StackTrace trace = new StackTrace(false);
                    string propertyName = trace.GetFrame(1).GetMethod().Name.Split('_')[1];
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                }
                catch
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(String.Empty));
                }
            }
        }

        #endregion

        #region IEnumerable<TreeItem> Members

        public IEnumerator<TreeItem> GetEnumerator()
        {
            return _children.GetEnumerator();
        }

        #endregion

        #region IEnumerable Members

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return _children.GetEnumerator();
        }

        #endregion
    }
}
