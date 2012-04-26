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
    /// Interaction logic for InputValidationViaValidationRules.xaml
    /// </summary>
    public partial class InputValidationViaValidationRules : Window
    {
        public InputValidationViaValidationRules()
        {
            InitializeComponent();

            Era baroqueEra = new Era
            {
                StartDate = new DateTime(1600, 1, 1),
                Duration = new DateTime(1750, 1, 1) - new DateTime(1600, 1, 1)
            };

            base.DataContext = baroqueEra;
        }
    }
}