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
using Microsoft.Windows.Controls.Ribbon;

namespace Grids
{
    /// <summary>
    /// Interaction logic for SyncfusionWindow.xaml
    /// </summary>
    public partial class SyncfusionWindow : RibbonWindow
    {
        public SyncfusionWindow()
        {
            InitializeComponent();
            humans = new HumanList();
            DGrid.ItemsSource = humans;
            DGrid.ExcelLikeCurrentCell = true;
            DGrid.ExcelLikeSelectionFrame = true;
            DGrid.ShowTableSummaries = true;
            DGrid.ShowRecordPlusMinus = true;
            DGrid.WrapCell = true;
        }

        private HumanList humans;

        private void ButCheckCollection_Click(object sender, RoutedEventArgs e)
        {
            humans.Message();
        }
    }
}
