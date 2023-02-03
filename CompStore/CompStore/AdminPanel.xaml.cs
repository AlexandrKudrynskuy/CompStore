using Bll.Service;
using Domain.Model;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
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
    /// Interaction logic for AdminPanel.xaml
    /// </summary>
    public partial class AdminPanel : Window
    {
        private readonly CategoryService categoryService;
        private readonly ProductService productService;
        private readonly CustomersService customersService;
        private readonly OrderService orderService;
        private readonly BrandService brandService;
        public ObservableCollection<Product> Products { get; set; }
        public ObservableCollection<Brand> Brands { get; set; }
        public ObservableCollection<Category> Categories { get; set; }
        public ObservableCollection<Order> Orders { get; set; }

        public AdminPanel(CategoryService _categoryService, ProductService _productService,
            CustomersService _customersService, OrderService _orderService, BrandService _brandService)
        {
            categoryService = _categoryService;
            productService = _productService;
            customersService = _customersService;
            orderService = _orderService;
            brandService = _brandService;

            InitializeComponent();

            Products = new ObservableCollection<Product>();
            ProductListView.ItemsSource = Products;
            Categories = new ObservableCollection<Category>();
            CategoryListView.ItemsSource = Categories;
            Brands = new ObservableCollection<Brand>();
            BrandListView.ItemsSource = Brands;
            Orders = new ObservableCollection<Order>(orderService.GetFromCondition(x => x.Id > 0));
            OrderListView.ItemsSource = Orders;

            CategoryListView.ItemsSource = categoryService.GetFromCondition(x => x.Id > 0);
            var obj = new object();
            var prod = new Product();
            HeaderDock.Resources.Add(obj, prod);

            File.Delete("user.txt");
        }




        private void Category_MouseUp(object sender, MouseButtonEventArgs e)
        {

            CategoryListView.ItemsSource = (categoryService.GetFromCondition(x => x.Id > 0));

        }



        private void CategoryChekBox_Checked(object sender, RoutedEventArgs e)
        {
            if (sender is CheckBox checkBox)
            {
                int id;
                int.TryParse(checkBox.Tag.ToString(), out id);
                var Prod = productService.GetFromCondition(x => x.CategoryID == id);
                if (checkBox.IsChecked == true)
                {

                    foreach (var item in Prod)
                    {
                        Products.Add(item);
                    }
                }
            }
        }

        private void CategoryChekBox_Unchecked(object sender, RoutedEventArgs e)
        {
            if (sender is CheckBox checkBox)
            {
                int id;
                int.TryParse(checkBox.Tag.ToString(), out id);
                var Prod = productService.GetFromCondition(x => x.CategoryID == id);
                if (checkBox.IsChecked == false)
                {

                    foreach (var item in Prod)
                    {
                        Products.Remove(item);
                    }
                }
            }
        }


        private void Client_MouseUp(object sender, MouseButtonEventArgs e)
        {
            ClientListView.ItemsSource = customersService.GetFromCondition(x => x.Id > 0);
        }

        private void Order_MouseUp(object sender, MouseButtonEventArgs e)
        {

        }

    

        private void Brend_MouseUp(object sender, MouseButtonEventArgs e)

        {
            var br = brandService.GetFromCondition(x => x.Id > 0);
            Brands = new ObservableCollection<Brand>(br);
            BrandListView.ItemsSource = Brands;

        }

        private void ChangeLogo_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                int id;
                int.TryParse(button.Tag.ToString(), out id);
                var brand = brandService.GetValue(id);
                brand.PhotoLogo = "https://upload.wikimedia.org/wikipedia/commons/thumb/8/82/Dell-Logo.svg/1280px-Dell-Logo.svg.png";
                brandService.Update(id, brand);
            }
        }

        private void AddBrand_Click(object sender, RoutedEventArgs e)
        {
            if (BrandNameAddTextBox.Text != null)
            {
                var brand = new Brand { Name = BrandNameAddTextBox.Text, PhotoLogo = LogoBrandNameAddTextBox.Text };
                brandService.Create(brand);
            }
            else
            {
                MessageBox.Show("Поле назва бренду не може бути порожнім");
            }
        }

        private void HeaderDock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.OriginalSource is TextBlock bl)
            {
                if (bl.Name==IdProductTextBlock.Name)
                {
                    Orders.Clear();
                    var List = (orderService.GetFromCondition(x => x.Id > 0)).OrderBy(x=>x.Id);
                    Orders = new ObservableCollection<Order>(List);
                    OrderListView.ItemsSource = Orders;

                }
                if (bl.Name==CuctomerNameTextBlock.Name)
                {
                    Orders.Clear();
                    var List = (orderService.GetFromCondition(x => x.Id > 0)).OrderBy(x => x.Customer.Name);
                    Orders = new ObservableCollection<Order>(List);
                    OrderListView.ItemsSource = Orders;
                }
                if (bl.Name==CustomerSurNameTextBlock.Name)
                {
                    Orders.Clear();
                    var List = (orderService.GetFromCondition(x => x.Id > 0)).OrderBy(x => x.Customer.SurName);
                    Orders = new ObservableCollection<Order>(List);
                    OrderListView.ItemsSource = Orders;
                }

                if (bl.Name == CategoryNameTextBlock.Name)
                {
                    Orders.Clear();
                    var List = (orderService.GetFromCondition(x => x.Id > 0)).OrderBy(x => x.Product.Category.Name);
                    Orders = new ObservableCollection<Order>(List);
                    OrderListView.ItemsSource = Orders;
                }
                if (bl.Name == BrandNameTextBlock.Name)
                {
                    Orders.Clear();
                    var List = (orderService.GetFromCondition(x => x.Id > 0)).OrderBy(x => x.Product.Brand.Name);
                    Orders = new ObservableCollection<Order>(List);
                    OrderListView.ItemsSource = Orders;
                }
                
                if (bl.Name == ModelNameTextBlock.Name)
                {
                    Orders.Clear();
                    var List = (orderService.GetFromCondition(x => x.Id > 0)).OrderBy(x => x.Product.Model);
                    Orders = new ObservableCollection<Order>(List);
                    OrderListView.ItemsSource = Orders;
                }
                if (bl.Name == DateOrderTextBlock.Name)
                {
                    Orders.Clear();
                    var List = (orderService.GetFromCondition(x => x.Id > 0)).OrderBy(x => x.DateOrder);
                    Orders = new ObservableCollection<Order>(List);
                    OrderListView.ItemsSource = Orders;
                }
            }
        }
    }
}
