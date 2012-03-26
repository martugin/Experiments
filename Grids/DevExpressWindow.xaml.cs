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
    /// Interaction logic for DevExpressWindow.xaml
    /// </summary>
    public partial class DevExpressWindow : RibbonWindow
    {
        public DevExpressWindow()
        {
            InitializeComponent();
            humans=new HumanList();
            DGrid.DataSource = humans;
            DGrid.View.AllowEditing = true;
            DGrid.View.AllowFilterEditor = true;
            DGrid.View.ClipboardCopyAllowed = true;
            DGrid.View.IsColumnChooserVisible = true;
            DGrid.View.IsColumnMenuEnabled = true;
            DGrid.View.IsRowCellMenuEnabled = true;
        }

        private HumanList humans;
    }
}
