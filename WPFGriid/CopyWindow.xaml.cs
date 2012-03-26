using System;
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
    /// Interaction logic for CopyWindow.xaml
    /// </summary>
    public partial class CopyWindow : Window
    {
        public CopyWindow()
        {
            InitializeComponent();
            humans = new ObservableCollection<Human>();
            for (int i = 0; i < 100000;++i )
                humans.Add(new Human("Вася", i, true));
            Gr.DataContext = humans;
            CGrid.IsTextSearchEnabled = true;
        }

        public ObservableCollection<Human> humans;

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            string s = Clipboard.GetText();
            MessageBox.Show(s);
            /*string[] sep = {"\t", "\r\n"};
            string[] cells = s.Split(sep,StringSplitOptions.None);
            string res = cells.Aggregate("", (current, cell) => current + (cell + ";"));
            MessageBox.Show(res);*/
            /*IDataObject da = Clipboard.GetDataObject();
            string[] formats = da.GetFormats();
            foreach (var format in formats)
            {
                MessageBox.Show(format);
            }*/
        }

        private ListCollectionView lhumans;

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            lhumans = CollectionViewSource.GetDefaultView(Gr.DataContext) as ListCollectionView;
            lhumans.MoveCurrentToLast();
            CGrid.ScrollIntoView(lhumans.CurrentItem);
            CGrid.Focus();
            /*lhumans.Filter = delegate(object item)
            {
                return ((Human)item).Age > 8;
            };*/

        }
    }
}
