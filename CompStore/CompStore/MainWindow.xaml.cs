﻿using Bll;
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
        public MainWindow(ProductService _productService, CategoryService categoryService )
        {
            //string nameFile = "Fon Store.jpg";
            //string fullPath = System.IO.Path.GetFullPath(nameFile);
            //ImageBrush b = new ImageBrush();
            //b.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Fon Start.jpg"));
            //start.Background = b;
            InitializeComponent();
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

            var cat =categoryService.GetFromCondition(x => x.Id == 3);
            var prod = productService.GetFromCondition(x => x.Price < 2300);

            //categoryService.Create(new Category { Name = "Others1" });
            //productService.Create(new Laptop { BrandId = 1, CategoryID = 1, Price = 22200, Model = "New", Discription = "Laptop", Hdd = 120, Processor = "I5", Ram = 4, Count = 12 });

            this.Show();

        }

        private void GoІhopping_Click(object sender, RoutedEventArgs e)
        {
            new StoreWindow().Show();
            this.Close();
        }

    }
}
