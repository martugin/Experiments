﻿using System;
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
    /// Interaction logic for InfagisticsWindow.xaml
    /// </summary>
    public partial class InfagisticsWindow : RibbonWindow
    {
        public InfagisticsWindow()
        {
            InitializeComponent();
            humans=new HumanList();
            DGrid.DataSource = humans;
            DGrid.IsUndoEnabled = true;
        }

        private HumanList humans;

        private void Col_Click(object sender, RoutedEventArgs e)
        {
            humans.Message();
        }
    }
}
