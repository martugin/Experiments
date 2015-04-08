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

namespace WPFGriid
{
    /// <summary>
    /// Interaction logic for DXWindow.xaml
    /// </summary>
    public partial class DXWindow : RibbonWindow
    {
        public DXWindow()
        {
            InitializeComponent();
            var humans = new ObservableCollection<Human>
                             {
                                 new Human("aaa", 10, false),
                                 new Human("ccc", 30, true),
                                 new Human("ddd", 40, true)
                             };
            var ent = new ProbaEntities();
            var query = from c in ent.FTabs select c;
            DXGrid.DataContext = query;
        }
    }
}
