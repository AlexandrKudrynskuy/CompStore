using Bll.Service;
using Domain.Model;
using Domain.Model.Products;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
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
        private readonly ProductService  productService;
        private readonly CustomersService customersService;
        public Customer Customer { get; set; }

        public ObservableCollection<Category> Categories { get; private set; }
        public ObservableCollection<Product> Products { get; private set; }

        public StoreWindow(CategoryService _categoryService, ProductService _productService, CustomersService _customersService)
        {
            //string nameFile = "Fon Store.jpg";
            //string fullPath = System.IO.Path.GetFullPath(nameFile);
            //ImageBrush b = new ImageBrush();
            //b.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Fon Store.jpg"));
            //store.Background = b;
            InitializeComponent();
            categoryService = _categoryService;
            productService = _productService;
            customersService = _customersService;
            Customer = new Customer();
            Products = new ObservableCollection<Product>(productService.GetFromCondition(x=>x.Id>0));
            Categories = new ObservableCollection<Category>(categoryService.GetFromCondition(x => x.Id > 0));
            CategoryListBox.ItemsSource = Categories;
            CategoryTreeView.Items.Clear();
            CategoryTreeView.ItemsSource = Categories;
            if (File.Exists("user.txt"))
            {
                var username = File.ReadAllText("user.txt");
                var listUser =customersService.GetFromCondition(x => x.Login == username);
                if (listUser.Count>0)
                {
                  Customer = listUser.First(x => x.Login == username);
                  File.Delete("user.txt");
                  
                }
            }
              
        }

        private void openCard_Click(object sender, RoutedEventArgs e)
        {
            var wind = App.provider.GetService<CardWindow>();
            wind.ShowDialog();
        }

        private void loginUser_Click(object sender, RoutedEventArgs e)
        {
            var wind = App.provider.GetService<LoginUser>();
            this.Close();
            wind.ShowDialog();
            
        }

        private void filtr_Click(object sender, RoutedEventArgs e)
        {

        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            CategoryListBox.Visibility = Visibility.Visible;
            back.Visibility = Visibility.Hidden;
            filtr.Visibility = Visibility.Hidden;
            storeScrol.Visibility = Visibility.Hidden;
        }


        private void TreeViewItem_MouseUp(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void CategoryButton_Click(object sender, RoutedEventArgs e)
        {
            CategoryListBox.Visibility = Visibility.Hidden;
            back.Visibility = Visibility.Visible;
            filtr.Visibility = Visibility.Visible;
            storeScrol.Visibility = Visibility.Visible;
            if (sender is Button butt)
            {
                int id;
                showProduct.Children.Clear();
                int.TryParse(butt.Tag.ToString(), out id);
                var Prod = productService.GetFromCondition(x => x.CategoryID == id);
                foreach (var item in Prod)
                {
                    showProduct.Children.Add(ShowCard(item));
                }
            }


        }

        private UIElement ShowCard(Product product)
        {
            var border = new Border();
            border.Width = 350;
            border.Height = 150;
            border.Background = Brushes.GhostWhite;
            border.BorderBrush = Brushes.Gainsboro;
            border.BorderThickness = new Thickness(1);
            border.CornerRadius = new CornerRadius(8, 8, 3, 3);
           

            var myGrid = new Grid();
            myGrid.Width = 340;
            myGrid.Height = 140;
            myGrid.HorizontalAlignment = HorizontalAlignment.Left;
          
            ColumnDefinition colDef1 = new ColumnDefinition();
            ColumnDefinition colDef2 = new ColumnDefinition();
            ColumnDefinition colDef3 = new ColumnDefinition();
            myGrid.ColumnDefinitions.Add(colDef1);
            myGrid.ColumnDefinitions.Add(colDef2);
            myGrid.ColumnDefinitions.Add(colDef3);

            RowDefinition rowDefinition1 = new RowDefinition();
            RowDefinition rowDefinition2 = new RowDefinition();
            RowDefinition rowDefinition3 = new RowDefinition();
            RowDefinition rowDefinition4 = new RowDefinition();
            RowDefinition rowDefinition5 = new RowDefinition();
            RowDefinition rowDefinition6 = new RowDefinition();
            myGrid.RowDefinitions.Add(rowDefinition1);
            myGrid.RowDefinitions.Add(rowDefinition2);
            myGrid.RowDefinitions.Add(rowDefinition3);
            myGrid.RowDefinitions.Add(rowDefinition4);
            myGrid.RowDefinitions.Add(rowDefinition5);
            myGrid.RowDefinitions.Add(rowDefinition6);

            ImageBrush im = new ImageBrush();
            im.ImageSource = new BitmapImage(new Uri(product.Photo, UriKind.RelativeOrAbsolute));
            var panel2 = new DockPanel();
            panel2.Background = im;
            panel2.Height = 90;
            panel2.Width = 100;
            Grid.SetRow(panel2, 1);
            Grid.SetColumn(panel2, 0);
            Grid.SetRowSpan(panel2, 4);

            var myStack = new StackPanel();
            myStack.Orientation = Orientation.Vertical;
            //var textBlockCategory = new TextBlock();
            //textBlockCategory.Text = product.Discription.ToString();
            //textBlockCategory.FontSize = 20;
            //textBlockCategory.FontFamily = new FontFamily("Gabriola");
            //myStack.Children.Add(textBlockCategory);
            
            var textBlockBrand = new TextBlock();
            textBlockBrand.Text = $"Бренд: {product.Brand.Name.ToString()}";
            textBlockBrand.FontSize = 20;
            textBlockBrand.FontFamily = new FontFamily("Gabriola");
            myStack.Children.Add(textBlockBrand);

            var textBlockModel = new TextBlock();
            textBlockModel.Text = $"Модель: {product.Model.ToString()}";
            textBlockModel.FontSize = 18;
            textBlockModel.FontFamily = new FontFamily("Gabriola");
            myStack.Children.Add(textBlockModel);

            var textBlockPrice = new TextBlock();
            textBlockPrice.Text = $"Ціна: {product.Price.ToString()}";
            textBlockPrice.FontSize = 19;
            textBlockPrice.FontFamily = new FontFamily("Gabriola");
            Grid.SetRow(textBlockPrice, 0);
            Grid.SetColumn(textBlockPrice, 2);
            myGrid.Children.Add(textBlockPrice);
            var but = new Button();
            but.Content = "Додати в корзину";
            but.Click += but_Click;
            but.FontSize = 12;
            Grid.SetRow(but, 2);
            Grid.SetColumn(but, 2);
            Grid.SetRowSpan(but, 2);
            myGrid.Children.Add(but);
            if (product is Laptop laptop)
            {
                var textBlockProc = new TextBlock();
                textBlockProc.Text = $"Проессор: {laptop.Processor.ToString()}";
                textBlockProc.FontSize = 15;
                textBlockProc.FontFamily = new FontFamily("Gabriola");
                myStack.Children.Add(textBlockProc);

                var textBlockRam = new TextBlock();
                textBlockRam.Text = $"Оперативна память: {laptop.Ram.ToString()}";
                textBlockRam.FontSize = 14;
                textBlockRam.FontFamily = new FontFamily("Gabriola");
                myStack.Children.Add(textBlockRam);

                Grid.SetRow(myStack, 0);
                Grid.SetRowSpan(myStack, 6);
                Grid.SetColumn(myStack,1);
                myGrid.Children.Add(panel2);
                myGrid.Children.Add(myStack);
                border.Child = myGrid;
                return border;
            }
            if (product is Display display)
            {
                var textBlockDiagonalSize = new TextBlock();
                textBlockDiagonalSize.Text = $"Діагональ: {display.DiagonalSize.ToString()}";
                textBlockDiagonalSize.FontSize = 15;
                textBlockDiagonalSize.FontFamily = new FontFamily("Gabriola");
                myStack.Children.Add(textBlockDiagonalSize);

                var textBlockColor = new TextBlock();
                textBlockColor.Text = $"Колір: {display.Color.ToString()}";
                textBlockColor.FontSize = 14;
                textBlockColor.FontFamily = new FontFamily("Gabriola");
                myStack.Children.Add(textBlockColor);

                Grid.SetRow(myStack, 0);
                Grid.SetRowSpan(myStack, 6);
                Grid.SetColumn(myStack, 1);
                myGrid.Children.Add(panel2);
                myGrid.Children.Add(myStack);
                border.Child = myGrid;
                return border;
            }
            if (product is MFU mfu)
            {
                var textBlockPrinterType = new TextBlock();
                textBlockPrinterType.Text = $"Тип: {mfu.PrinterType.ToString()}";
                textBlockPrinterType.FontSize = 15;
                textBlockPrinterType.FontFamily = new FontFamily("Gabriola");
                myStack.Children.Add(textBlockPrinterType);

                

                Grid.SetRow(myStack, 0);
                Grid.SetRowSpan(myStack, 6);
                Grid.SetColumn(myStack, 1);
                myGrid.Children.Add(panel2);
                myGrid.Children.Add(myStack);
                border.Child = myGrid;
                return border;
            }
            if (product is Speaker speaker)
            {
                var textBlockPower = new TextBlock();
                textBlockPower.Text = $"Потужність: {speaker.Power.ToString()}";
                textBlockPower.FontSize = 15;
                textBlockPower.FontFamily = new FontFamily("Gabriola");
                myStack.Children.Add(textBlockPower);

                var textBlockColor = new TextBlock();
                textBlockColor.Text = $"Колір: {speaker.Color.ToString()}";
                textBlockColor.FontSize = 14;
                textBlockColor.FontFamily = new FontFamily("Gabriola");
                myStack.Children.Add(textBlockColor);

                Grid.SetRow(myStack, 0);
                Grid.SetRowSpan(myStack, 6);
                Grid.SetColumn(myStack, 1);
                myGrid.Children.Add(panel2);
                myGrid.Children.Add(myStack);
                border.Child = myGrid;
                return border;
            }



            border.Child = myGrid;
           
            
           
            return border;
        }

        private void but_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
