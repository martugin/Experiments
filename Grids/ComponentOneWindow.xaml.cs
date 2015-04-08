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
using Microsoft.Windows.Controls.Ribbon;

namespace Grids
{
    /// <summary>
    /// Interaction logic for ComponentOneWindow.xaml
    /// </summary>
    public partial class ComponentOneWindow : RibbonWindow
    {
        public ComponentOneWindow()
        {
            InitializeComponent();
            DGrid.ItemsSource = new HumanList(); 
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
