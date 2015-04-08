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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DetailedTree
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
			
			//Устанавливаем источник данных
			detailedTreeView.ItemsSource = GetTree();
        }

		/// <summary>
		/// Заполняет дерево для примера
		/// </summary>
		/// <returns>Дерево элементов</returns>
        private TreeItem GetTree()
        {
            TreeItem treeRoot = new TreeItem();
            treeRoot.Title = "root";
            treeRoot.Children.Add(new TreeItem() { Title = "Dire Straits", Raiting = "component/Images/3758.ico"});
			treeRoot.Children[0].Children.Add(new TreeItem() { Title = "Platinum", Raiting = "/DetailedTree;component/Images/00035.ico" });
			treeRoot.Children[0].Children[0].Children.Add(new TreeItem() { Title = "1 - Money For Nothing", Raiting = "/DetailedTree;component/Images/00557.ico", DateTime = "4:07" });

            treeRoot.Children.Add(new TreeItem() { Title = "Deep Purple", Raiting = "/DetailedTree;component/Images/00557.ico" });
            treeRoot.Children[1].Children.Add(new TreeItem() { Title = "Made In Jappan", Raiting = "/DetailedTree;component/Images/00035.ico", DateTime = "1972" });
            treeRoot.Children[1].Children[0].Children.Add(new TreeItem() { Title = "1 - Highway Star", Raiting = "/DetailedTree;component/Images/3758.ico", DateTime = "6:51" });
            treeRoot.Children[1].Children[0].Children.Add(new TreeItem() { Title = "2 - Child in Time", Raiting = "/DetailedTree;component/Images/3758.ico", DateTime = "12:24" });
            treeRoot.Children[1].Children[0].Children.Add(new TreeItem() { Title = "3 - The Smoke on the Water", Raiting = "/DetailedTree;component/Images/3758.ico", DateTime = "7:32" });

			return treeRoot;
        }

        private void detailedTreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            MessageBox.Show(((TreeItem)e.NewValue).Raiting);
        }
    }
}
