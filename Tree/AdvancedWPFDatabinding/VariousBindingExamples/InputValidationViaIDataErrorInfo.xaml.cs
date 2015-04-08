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
    /// Interaction logic for InputValidationViaIDataErrorInfo.xaml
    /// </summary>
    public partial class InputValidationViaIDataErrorInfo : Window
    {
        public InputValidationViaIDataErrorInfo()
        {
            InitializeComponent();

            SmartEra baroqueEra = new SmartEra
            {
                StartDate = new DateTime(1600, 1, 1),
                Duration = new DateTime(1750, 1, 1) - new DateTime(1600, 1, 1)
            };

            base.DataContext = baroqueEra;
        }
    }
}
