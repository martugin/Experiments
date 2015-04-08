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

namespace VariousBindingExamples
{
    public partial class WorkingWithTemplates : Window
    {
        // This is the Window's constructor.
        public WorkingWithTemplates()
        {
            InitializeComponent();

            base.DataContext = new FullName[]
            {
                new FullName 
                { 
                    FirstName = "Johann", 
                    MiddleInitial = 'S', 
                    LastName = "Bach" 
                },
                new FullName 
                { 
                    FirstName = "Gustav",
                    MiddleInitial = ' ',
                    LastName = "Mahler" 
                },
                new FullName 
                { 
                    FirstName = "Alfred", 
                    MiddleInitial = 'G', 
                    LastName = "Schnittke" 
                }
            };
        }
    }
}