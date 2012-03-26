using System;
using System.Collections.Generic;
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
    /// Interaction logic for ProbaWindow.xaml
    /// </summary>
    public partial class ProbaWindow : Window
    {
        public ProbaWindow()
        {
            InitializeComponent();
            _ent = new ProbaEntities();
            var query = from f in _ent.FTabs select f;
            ProbaGrid.ItemsSource = query;
        }

        private ProbaEntities _ent;

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            _ent.SaveChanges();
        }
    }
}
