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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Windows.Controls.Ribbon;

namespace Grids
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : RibbonWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            Humans=new HumanList();
            DGrid.ItemsSource = Humans;
        }

        public HumanList Humans;

        private void ButTelerik_Click(object sender, RoutedEventArgs e)
        {
            (new TelerikWindow()).Show();
        }

        private void ButSyncFusion_Click(object sender, RoutedEventArgs e)
        {
            (new SyncfusionWindow()).Show();
        }

        private void ButDevExpress_Click(object sender, RoutedEventArgs e)
        {
            (new DevExpressWindow()).Show();
        }

        private void ButInfagistics_Click(object sender, RoutedEventArgs e)
        {
            (new InfagisticsWindow()).Show();
        }

        private void ButXceed_Click(object sender, RoutedEventArgs e)
        {
            (new XceedWindow()).Show();
        }

        private void ButComponentOne_Click(object sender, RoutedEventArgs e)
        {
            (new ComponentOneWindow()).Show();
        }

        private void ButTelDataSet_Click(object sender, RoutedEventArgs e)
        {
            (new TelDataSetWindow()).Show();
        }

        private void ButDevDataSet_Click(object sender, RoutedEventArgs e)
        {
            (new DevDataSetWindow()).Show();
        }

        private void ButComponentArt_Click(object sender, RoutedEventArgs e)
        {
            (new ComponentArtWindow()).Show();
        }
    }
}
