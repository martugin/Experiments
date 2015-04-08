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
    /// <summary>
    /// Interaction logic for UsingManyControls_BusinessObjects.xaml
    /// </summary>
    public partial class UsingManyControls_BusinessObjects : Window
    {
        public UsingManyControls_BusinessObjects()
        {
            InitializeComponent();

            base.DataContext = Customer.CreateCustomers();
        }
    }
}