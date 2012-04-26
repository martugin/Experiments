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
using System.Collections.ObjectModel;

namespace Grids
{
    /// <summary>
    /// Interaction logic for TelerikWindow.xaml
    /// </summary>
    public partial class TelerikWindow : RibbonWindow
    {
        public TelerikWindow()
        {
            InitializeComponent();
            DGrid.ItemsSource = new HumanList();
            DGrid.CanUserInsertRows = true;
            DGrid.CanUserInsertRows = true;
            DGrid.ShowInsertRow = true;
        }
    }
}
