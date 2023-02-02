using Bll;
using Bll.Service;
using Dll.Context;
using Domain.Model;
using Domain.Model.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CompStore
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly CustomersService customersService;
        public MainWindow(CustomersService _customersService)
        {
            InitializeComponent();
             customersService = _customersService;
            //Expression<Func<Laptop, bool>> expression = x => x.Id != null;
            //string NameTextBox1_Text = null;
            //string AgeTextBox1_Text = "as";
            //string DateTextBox1_Text = "yes";
            //if (NameTextBox1_Text != null)
            //{
            //    expression = x => x.Price < 4000;

            //}

            //if (DateTextBox1_Text != null)
            //{
            //    expression = x => x.BrandId == 1;
            //}

            //var cat =categoryService.GetFromCondition(x => x.Id == 3);
            //var prod = productService.GetFromCondition(x => x.Price < 2300);

            //categoryService.Create(new Category { Name = "Others1" });
            //productService.Create(new Laptop { BrandId = 1, CategoryID = 1, Price = 22200, Model = "New", Discription = "Laptop", Hdd = 120, Processor = "I5", Ram = 4, Count = 12 });

            this.Show();

        }

        private void GoІhopping_Click(object sender, RoutedEventArgs e)
        {

        }

      
        private void LoginAdmin_Click(object sender, RoutedEventArgs e)
        {
            var cust = customersService.Login(LoginTextBox.Text, PasswordPaswordBox.Password);
            if (cust!=null && cust.TypeUser==TypeUser.Admin)
            {
                var mainWindow = App.provider.GetService<AdminPanel>();
                this.Visibility = Visibility.Hidden;
                mainWindow.ShowDialog();
                this.Visibility = Visibility.Visible;
            }
            else
            {
                MessageBox.Show("Логін або пароль неправильний, або ви не адміністратор");
            }
        }
    }
}
