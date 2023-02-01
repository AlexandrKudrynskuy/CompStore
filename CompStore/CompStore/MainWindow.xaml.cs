using Bll;
using Bll.Service;
using Dll.Context;
using Domain.Model;
using Domain.Model.Products;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
        private readonly ProductService productService;
        public MainWindow(ProductService _productService)
        {
            //InitializeComponent();
            productService = _productService;
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


            this.Show();

        }
    }
}
