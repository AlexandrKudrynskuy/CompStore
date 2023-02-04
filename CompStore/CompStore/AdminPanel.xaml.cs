using Bll.Service;
using Domain.Model;
using Domain.Model.Products;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;

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
        public Product Product { get; set; }
        public MFU Mfu { get; set; }

        public Laptop Laptop { get; set; }
        public Display Display { get; set; }
        public Speaker Speaker { get; set; }


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
            Product = new Product();
            Mfu = new MFU();
            Laptop = new Laptop();
            Display = new Display();
            Speaker = new Speaker();
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
            //var obj = new object();
            //var prod = new Product();
            //HeaderDock.Resources.Add(obj, prod);
            CategoryComboBox.ItemsSource = categoryService.GetFromCondition(x => x.Id > 0);
            BrandComboBox.ItemsSource = brandService.GetFromCondition(x => x.Id > 0);

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
                if (bl.Name == IdProductTextBlock.Name)
                {
                    Orders.Clear();
                    var List = (orderService.GetFromCondition(x => x.Id > 0)).OrderBy(x => x.Id);
                    Orders = new ObservableCollection<Order>(List);
                    OrderListView.ItemsSource = Orders;

                }
                if (bl.Name == CuctomerNameTextBlock.Name)
                {
                    Orders.Clear();
                    var List = (orderService.GetFromCondition(x => x.Id > 0)).OrderBy(x => x.Customer.Name);
                    Orders = new ObservableCollection<Order>(List);
                    OrderListView.ItemsSource = Orders;
                }
                if (bl.Name == CustomerSurNameTextBlock.Name)
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

        private void SaveCountButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                if (button.Parent is DockPanel dockPanel)
                {
                    foreach (var child in dockPanel.Children)
                    {
                        if (child is TextBox childTextBox)
                            if (childTextBox.Tag != null && (button.Tag.ToString() == childTextBox.Tag.ToString()))
                            {
                                int id;
                                if (int.TryParse(button.Tag.ToString(), out id))
                                {
                                    int Count;
                                    int.TryParse(childTextBox.Text.ToString(), out Count);
                                    var Prod = productService.GetValue(id);
                                    for (int i = 0; i < Count; i++)
                                    {
                                        Prod.Count++;
                                        productService.Update(id, Prod);
                                    }
                                }

                            }
                    }
                }
            }
        }

        private void AddProduct(object sender, RoutedEventArgs e)
        {
            if (CategoryComboBox.SelectedItem is Category cat)
            {
                Product.CategoryID = cat.Id;
            }
            if (BrandComboBox.SelectedItem is Brand brand)
            {
                Product.BrandId = brand.Id;
            }
            if (Product.CategoryID == (int)CategoryEnum.MFU)
            {
                Mfu.CategoryID = Product.CategoryID;
                Mfu.BrandId = Product.BrandId;
                Mfu.Model = Product.Model;
                Mfu.Price = Product.Price;
                Mfu.Discription = Product.Discription;
                Mfu.Count = Product.Count;

                productService.Create(Mfu);
            }

            if (Product.CategoryID == (int)CategoryEnum.Laptops)
            {
                Laptop.CategoryID = Product.CategoryID;
                Laptop.BrandId = Product.BrandId;
                Laptop.Model = Product.Model;
                Laptop.Price = Product.Price;
                Laptop.Discription = Product.Discription;
                Laptop.Count = Product.Count;

                productService.Create(Laptop);
            }

            if (Product.CategoryID == (int)CategoryEnum.Display)
            {
                Display.CategoryID = Product.CategoryID;
                Display.BrandId = Product.BrandId;
                Display.Model = Product.Model;
                Display.Price = Product.Price;
                Display.Discription = Product.Discription;
                Display.Count = Product.Count;

                productService.Create(Display);
            }

            if (Product.CategoryID == (int)CategoryEnum.Speakers)
            {
                Speaker.CategoryID = Product.CategoryID;
                Speaker.BrandId = Product.BrandId;
                Speaker.Model = Product.Model;
                Speaker.Price = Product.Price;
                Speaker.Discription = Product.Discription;
                Speaker.Count = Product.Count;

                productService.Create(Speaker);
            }
        }
        private void CategoryComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (sender is ComboBox categoryChekBox)
            {
                if (categoryChekBox.SelectedItem is Category Cat)
                {
                    var stackPanelHeaderMFU = new StackPanel();
                    var stackPanelValueMFU = new StackPanel();
                    var stackPanelHeaderLaptops = new StackPanel();
                    var stackPanelValueLaptops = new StackPanel();
                    var stackPanelHeaderDisplay = new StackPanel();
                    var stackPanelValueDisplay = new StackPanel();
                    var stackPanelHeaderSpeakers = new StackPanel();
                    var stackPanelValueSpeakers = new StackPanel();

                    SmailHeaderStackPanel.Children.Clear();
                    SmailValueStackPanel.Children.Clear();

                    if (Cat.Id == (int)CategoryEnum.MFU)
                    {


                        stackPanelHeaderMFU.Children.Add(new TextBlock { Text = "Dpi", Margin = new Thickness(5) });
                        stackPanelHeaderMFU.Children.Add(new TextBlock { Text = "ColorCount", Margin = new Thickness(5) });
                        stackPanelHeaderMFU.Children.Add(new TextBlock { Text = "HasWiFi", Margin = new Thickness(5) });

                        var DpiTextBox = new TextBox { Margin = new Thickness(5) };
                        DpiTextBox.LostFocus += DpiTextBox_LostFocus;

                        var ColorCountTextBox = new TextBox { Margin = new Thickness(5) };
                        ColorCountTextBox.LostFocus += ColorCountTextBox_LostFocus;

                        var HasWiFiChekBox = new CheckBox { Margin = new Thickness(5) };
                        HasWiFiChekBox.Checked += HasWiFiChekBox_Checked;

                        stackPanelValueMFU.Children.Add(DpiTextBox);
                        stackPanelValueMFU.Children.Add(ColorCountTextBox);
                        stackPanelValueMFU.Children.Add(HasWiFiChekBox);


                        SmailHeaderStackPanel.Children.Add(stackPanelHeaderMFU);
                        SmailValueStackPanel.Children.Add(stackPanelValueMFU);
                    }

                    if (Cat.Id == (int)CategoryEnum.Laptops)
                    {

                        stackPanelHeaderLaptops.Children.Add(new TextBlock { Text = "Hdd", Margin = new Thickness(5) });
                        stackPanelHeaderLaptops.Children.Add(new TextBlock { Text = "Ram", Margin = new Thickness(5) });
                        stackPanelHeaderLaptops.Children.Add(new TextBlock { Text = "Processor", Margin = new Thickness(5) });


                        var ProcessorTextBox = new TextBox { Margin = new Thickness(5) };
                        var HddTextBox = new TextBox { Margin = new Thickness(5) };
                        var RamCountTextBox = new TextBox { Margin = new Thickness(5) };
                        ProcessorTextBox.LostFocus += ProcessorTextBox_LostFocus;
                        HddTextBox.LostFocus += HddTextBox_LostFocus;
                        RamCountTextBox.LostFocus += RamCountTextBox_LostFocus;
                        stackPanelValueLaptops.Children.Add(HddTextBox);
                        stackPanelValueLaptops.Children.Add(RamCountTextBox);
                        stackPanelValueLaptops.Children.Add(ProcessorTextBox);

                        SmailHeaderStackPanel.Children.Add(stackPanelHeaderLaptops);
                        SmailValueStackPanel.Children.Add(stackPanelValueLaptops);


                    }
                    if (Cat.Id == (int)CategoryEnum.Display)
                    {


                        stackPanelHeaderDisplay.Children.Add(new TextBlock { Text = "Diagonal", Margin = new Thickness(5) });
                        stackPanelHeaderDisplay.Children.Add(new TextBlock { Text = "Resolution", Margin = new Thickness(5) });
                        stackPanelHeaderDisplay.Children.Add(new TextBlock { Text = "Color", Margin = new Thickness(5) });


                        var DiagonalTextBox = new TextBox { Name = "DiagonalTextBox", Margin = new Thickness(5) };
                        var ResolutionTextBox = new TextBox { Name = "ResolutionTextBox", Margin = new Thickness(5) };
                        var ColorTextBox = new TextBox { Name = "ColorTextBox", Margin = new Thickness(5) };
                        DiagonalTextBox.LostFocus += DiagonalTextBox_LostFocus;
                        ResolutionTextBox.LostFocus += ResolutionTextBox_LostFocus;
                        ColorTextBox.LostFocus += ColorTextBox_LostFocus;
                        stackPanelValueDisplay.Children.Add(DiagonalTextBox);
                        stackPanelValueDisplay.Children.Add(ResolutionTextBox);
                        stackPanelValueDisplay.Children.Add(ColorTextBox);



                        SmailHeaderStackPanel.Children.Add(stackPanelHeaderDisplay);
                        SmailValueStackPanel.Children.Add(stackPanelValueDisplay);
                    }

                    if (Cat.Id == (int)CategoryEnum.Speakers)
                    {


                        stackPanelHeaderSpeakers.Children.Add(new TextBlock { Text = "Power", Margin = new Thickness(5) });
                        stackPanelHeaderSpeakers.Children.Add(new TextBlock { Text = "Width", Margin = new Thickness(5) });
                        stackPanelHeaderSpeakers.Children.Add(new TextBlock { Text = "Height", Margin = new Thickness(5) });
                        stackPanelHeaderSpeakers.Children.Add(new TextBlock { Text = "Color", Margin = new Thickness(5) });

                        var PowerTextBox = new TextBox { Margin = new Thickness(5) };
                        var WidthTextBox = new TextBox { Margin = new Thickness(5) };
                        var HeightTextBox = new TextBox { Margin = new Thickness(5) };
                        var ClolrSpekTextBox = new TextBox { Margin = new Thickness(5) };

                        PowerTextBox.LostFocus += PowerTextBox_LostFocus;
                        WidthTextBox.LostFocus+= WidthTextBox_LostFocus;
                        HeightTextBox.LostFocus+= HeightTextBox_LostFocus;
                        ClolrSpekTextBox.LostFocus += ClolrSpekTextBox_Lost_Focus;
                        stackPanelValueSpeakers.Children.Add(PowerTextBox);
                        stackPanelValueSpeakers.Children.Add(WidthTextBox);
                        stackPanelValueSpeakers.Children.Add(HeightTextBox);
                        stackPanelValueSpeakers.Children.Add(ClolrSpekTextBox);

                        SmailHeaderStackPanel.Children.Add(stackPanelHeaderSpeakers);
                        SmailValueStackPanel.Children.Add(stackPanelValueSpeakers);

                    }
                    var AddProductButton = new Button { Content = "Add" };
                    SmailHeaderStackPanel.Children.Add(AddProductButton);
                    AddProductButton.Click += AddProduct;
                }
            }
        }

        private void ClolrSpekTextBox_Lost_Focus(object sender, RoutedEventArgs e)
        {

            if (sender is TextBox textBox)
            {
                Speaker.Color = textBox.Text;
            }
        }

        private void HeightTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox textBox)
            {
                Speaker.Heigth = int.Parse(textBox.Text);
            }
        }

        private void WidthTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox textBox)
            {
                Speaker.Width = int.Parse(textBox.Text);
            }
        }

        private void PowerTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox textBox)
            {
                Speaker.Power = int.Parse(textBox.Text);
            }
        }

        private void ColorTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox textBox)
            {
                Display.Color = textBox.Text;
            }
        }

        private void ResolutionTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox textBox)
            {
                Display.Resolution = textBox.Text;
            }
        }

        private void DiagonalTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox textBox)
            {
                Display.DiagonalSize = Double.Parse(textBox.Text);
            }
        }

        private void RamCountTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox textBox)
            {
                Laptop.Ram = int.Parse(textBox.Text);
            }
        }

        private void HddTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox textBox)
            {
                Laptop.Hdd = int.Parse(textBox.Text);
            }
        }

        private void ProcessorTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox textBox)
            {
                Laptop.Processor = textBox.Text;
            }
        }

        private void HasWiFiChekBox_Checked(object sender, RoutedEventArgs e)
        {

            if (sender is CheckBox checkBox)
            {
                if (checkBox.IsChecked != null)
                {
                    Mfu.HasWiFi = (bool)checkBox.IsChecked;
                }
            }
        }

        private void ColorCountTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox textBox)
            {
                Mfu.ColorCount = int.Parse(textBox.Text);
            }
        }

        private void DpiTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox textBox)
            {

                Mfu.DPI = textBox.Text;
            }
        }

        private void AddProdModelTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (AddProdModelTextBox.Text != null)
            {
                Product.Model = AddProdModelTextBox.Text;
            }
        }

        private void AddProdPrice_LostFocus(object sender, RoutedEventArgs e)
        {
            if (AddProdPrice.Text != null)
            {
                Product.Price = double.Parse(AddProdPrice.Text);

            }
        }

        private void AddProdCount_LostFocus(object sender, RoutedEventArgs e)
        {
            if (AddProdCount.Text != null)
            {
                Product.Count = int.Parse(AddProdCount.Text);
            }
        }

        private void AddProdDiscription_LostFocus(object sender, RoutedEventArgs e)
        {
            if (AddProdDiscription.Text != null)
            {
                Product.Discription = AddProdDiscription.Text;
            }

        }

        private void AddProdPhoto_LostFocus(object sender, RoutedEventArgs e)
        {
            if (AddProdPhoto.Text != null)
            {
                Product.Photo = AddProdPhoto.Text;
            }

        }
    }
}
