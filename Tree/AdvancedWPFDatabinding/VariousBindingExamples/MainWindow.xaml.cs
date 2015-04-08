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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            base.DataContext = new WindowHolder[]
            {
                new WindowHolder {WindowType=typeof(BindingInCode), Title="Binding in Code"},
                new WindowHolder {WindowType=typeof(WorkingWithTemplates), Title="Working with Templates"},
                new WindowHolder {WindowType=typeof(UsingManyControls_XML), Title="Using Many Controls (XML)"},
                new WindowHolder {WindowType=typeof(UsingManyControls_BusinessObjects), Title="Using Many Controls (Objects)"},
                new WindowHolder {WindowType=typeof(UsingOneControl), Title="Using One Control to Display an Entire Hierarchy"},
                new WindowHolder {WindowType=typeof(UsingHierarchicalDataTemplates), Title="Using Hierarchical Data Templates"},
                new WindowHolder {WindowType=typeof(InputValidationViaValidationRules), Title="Input Validation via ValidationRules"},
                new WindowHolder {WindowType=typeof(InputValidationViaIDataErrorInfo), Title="Input Validation via IDataErrorInfo"},
            };
        }

        void OnButtonClick(object sender, RoutedEventArgs e)
        {
            Button btn = e.OriginalSource as Button;
            WindowHolder holder = btn.Tag as WindowHolder;
            Window wnd = Activator.CreateInstance(holder.WindowType) as Window;
            wnd.Owner = this;
            wnd.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            wnd.ShowDialog();
        }
    }

    class WindowHolder
    {
        public Type WindowType { get; set; }
        public string Title { get; set; }
    }
}