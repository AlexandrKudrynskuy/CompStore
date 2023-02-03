using Bll.Service;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CompStore
{
    /// <summary>
    /// Interaction logic for StoreWindow.xaml
    /// </summary>
    public partial class StoreWindow : Window
    {
        private readonly CategoryService categoryService;
        public ObservableCollection<Category> Categories { get; private set; }
        public StoreWindow(CategoryService _categoryService)
        {
            //string nameFile = "Fon Store.jpg";
            //string fullPath = System.IO.Path.GetFullPath(nameFile);
            //ImageBrush b = new ImageBrush();
            //b.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Fon Store.jpg"));
            //store.Background = b;
            InitializeComponent();
            categoryService = _categoryService;
            Categories = new ObservableCollection<Category>(categoryService.GetFromCondition(x=>x.Id>0));
            CategoryListBox.ItemsSource = Categories;
        }

        private void openCard_Click(object sender, RoutedEventArgs e)
        {

        }

        private void loginUser_Click(object sender, RoutedEventArgs e)
        {

        }

        private void filtr_Click(object sender, RoutedEventArgs e)
        {

        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            //storeProduct.Visibility = Visibility.Visible;
            //back.Visibility = Visibility.Hidden;
            //filtr.Visibility = Visibility.Hidden;
        }

        private void laptopButton_Click(object sender, RoutedEventArgs e)
        {
            //storeProduct.Visibility = Visibility.Hidden;
            //back.Visibility = Visibility.Visible;
            //filtr.Visibility = Visibility.Visible;
            //var lap = categoryService.GetValue(1);


        }

        private void mfuButton_Click(object sender, RoutedEventArgs e)
        {
            //storeProduct.Visibility = Visibility.Hidden;
            //back.Visibility = Visibility.Visible;
            //filtr.Visibility = Visibility.Visible;
        }

        private void displayButton_Click(object sender, RoutedEventArgs e)
        {
            //storeProduct.Visibility = Visibility.Hidden;
            //back.Visibility = Visibility.Visible;
            //filtr.Visibility = Visibility.Visible;
        }

        private void speakerButton_Click(object sender, RoutedEventArgs e)
        {
            //storeProduct.Visibility = Visibility.Hidden;
            //back.Visibility = Visibility.Visible;
            //filtr.Visibility = Visibility.Visible;
        }
    }
}
