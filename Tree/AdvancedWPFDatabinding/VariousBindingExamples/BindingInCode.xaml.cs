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
using System.Diagnostics;

namespace VariousBindingExamples
{
    /// <summary>
    /// Interaction logic for BindingInCode.xaml
    /// </summary>
    public partial class BindingInCode : Window
    {
        public BindingInCode()
        {
            InitializeComponent();

            base.DataContext = new Person { Name = "Josh Smith" };

            BindText(this.textBox, "Name");

            bool validated = IsTextValidated(this.textBox);
            Debug.WriteLine("Is Text validated? " + validated);

            UnbindText(this.textBox);

            this.textBox.Text = "This is some unbound text...";
        }

        static void BindText(TextBox textBox, string property)
        {
            DependencyProperty textProp = TextBox.TextProperty;
            if (!BindingOperations.IsDataBound(textBox, textProp))
            {
                Binding b = new Binding(property);
                BindingOperations.SetBinding(textBox, textProp, b);
            }
        }

        static bool IsTextValidated(TextBox textBox)
        {
            DependencyProperty textProp = TextBox.TextProperty;

            var expr = textBox.GetBindingExpression(textProp);
            if (expr == null)
                return false;

            Binding b = expr.ParentBinding;
            return b.ValidationRules.Any();
        }

        static void UnbindText(TextBox textBox)
        {
            DependencyProperty textProp = TextBox.TextProperty;
            if (BindingOperations.IsDataBound(textBox, textProp))
            {
                BindingOperations.ClearBinding(textBox, textProp);
            }
        }
    }
}