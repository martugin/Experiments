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

namespace WPFGriid
{
    /// <summary>
    /// Interaction logic for TelerikWindow.xaml
    /// </summary>
    public partial class TelerikWindow : Window
    {
        public TelerikWindow()
        {
            InitializeComponent();
            /*var humans = new ObservableCollection<Human>
                             {
                                 new Human("aaa", 12, true),
                                 new Human("bbb", 13, false)
                             };
            TGid.ItemsSource = humans;*/
            var ent = new ProbaEntities();
            var query = from c in ent.FTabs select c;
            TGrid.ItemsSource = query;
        }
    }
}
