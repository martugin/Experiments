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
    /// Interaction logic for XceedWindow.xaml
    /// </summary>
    public partial class XceedWindow : Window
    {
        public XceedWindow()
        {
            InitializeComponent();
            var humans = new ObservableCollection<Human>
                             {
                                 new Human("a", 10, true),
                                 new Human("b", 20, false),
                                 new Human("c", 30, true)
                             };
            XGrid.ItemsSource = humans;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
        }
      
    }
}
