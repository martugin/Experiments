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
    /// Interaction logic for XceedWindow.xaml
    /// </summary>
    public partial class XceedWindow : RibbonWindow
    {
        public XceedWindow()
        {
            InitializeComponent();
            DGrid.ItemsSource = new HumanList();
            DGrid.AllowDetailToggle = true;
            DGrid.AutoCreateDetailConfigurations = true;
            DGrid.Columns[0].AllowAutoFilter=true;
            DGrid.Columns[1].AllowAutoFilter = true;
        }

        private HumanList humans;

    }
}
