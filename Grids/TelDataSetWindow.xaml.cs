using System;
using System.Collections;
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
    /// Interaction logic for TelDataSetWindow.xaml
    /// </summary>
    public partial class TelDataSetWindow : RibbonWindow
    {
        public TelDataSetWindow()
        {
            InitializeComponent();
            var h = new ProjectTemplateDataSetTableAdapters.CalcParams_OldTableAdapter().GetData();
            DGrid.ItemsSource = h;
            DPager.Source = h;
        }
    }
}
