using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.Generic;

namespace WPFGriid
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ListLL = new ObservableCollection<LL>
                         {
                             new LL("aaa", "bbb")
                                 {
                                     Children = new ObservableCollection<MM>{new MM("11", "22"), new MM("33","44")}
                                 }, 
                             new LL("ccc", "ddd")
                                 {
                                     Children = new ObservableCollection<MM>{new MM("101", "202"), new MM("303","404")}
                                 }
                         };
            DGrid.ItemsSource = ListLL;
        }

        private ObservableCollection<LL> ListLL;

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(ListLL[0].F + "; " + ListLL[0].S);
        }

        private void butList_Click(object sender, RoutedEventArgs e)
        {
            var w = new WindowList();
            w.Show();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            var w = new CopyWindow();
            w.Show();
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            (new ProbaWindow()).Show();
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            (new XceedWindow()).Show();
        }

        private void button5_Click(object sender, RoutedEventArgs e)
        {
            (new DXWindow()).Show();
        }

        private void button6_Click(object sender, RoutedEventArgs e)
        {
            (new InfaWindow()).Show(); 
        }

        private void button7_Click(object sender, RoutedEventArgs e)
        {
            (new TelerikWindow()).Show();
        } 
    }

    public class MM
    {
        public MM(string d, string e)
        {
            D = d;
            E = e;
        }

        public string D { get; set; }
        public string E { get; set; }
    }

    public class LL : INotifyPropertyChanged
    {
        public LL(string f, string s)
        {
            F = f;
            S = s;
            B = false;
        }

        private ObservableCollection<MM> _children;
        public ObservableCollection<MM> Children
        {
            get { return _children; }
            set
            {
                _children = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Children"));
            }
        }

        private string _f;
        public string F
        {
            get { return _f; }
            set
            {
                _f = value;
                OnPropertyChanged(new PropertyChangedEventArgs("F"));
            }
        }

        private string _s;
        public string S
        {
            get { return _s; }
            set
            {
                _s = value;
                OnPropertyChanged(new PropertyChangedEventArgs("S"));
            }
        }

        private bool _b;
        public bool B
        {
            get { return _b; }
            set
            {
                _b = value;
                OnPropertyChanged(new PropertyChangedEventArgs("B"));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, e);
        }
    }
}
