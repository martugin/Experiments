﻿using System;
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
    /// Interaction logic for DevDataSetWindow.xaml
    /// </summary>
    public partial class DevDataSetWindow : RibbonWindow
    {
        public DevDataSetWindow()
        {
            InitializeComponent();
            DGrid.DataSource = new ProjectTemplateDataSetTableAdapters.CalcParams_OldTableAdapter().GetData();
        }
    }
}
