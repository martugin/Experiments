using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WPFGriid
{
    /// <summary>
    /// Interaction logic for WindowList.xaml
    /// </summary>
    public partial class WindowList : Window
    {
        public WindowList()
        {
            InitializeComponent();
            humans = new ObservableCollection<Human>
                         {
                             new Human("Вася", 4, false), 
                             new Human("Петя", 50, true)
                         };
            listBox1.ItemsSource = humans;
            listBox2.ItemsSource = humans;
        }

        private ObservableCollection<Human> humans;

    }
}
