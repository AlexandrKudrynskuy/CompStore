using Domain.Model.Products;
using Domain.Model;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for CardWindow.xaml
    /// </summary>
    public partial class CardWindow : Window
    {
        public CardWindow()
        {
            InitializeComponent();
        }

        private void Order_Click(object sender, RoutedEventArgs e)
        {

        }
        private UIElement ShowCard(Product product)
        {
            var mygrid = new Grid();
            mygrid.Width = 400;
            mygrid.Height = 50;
            mygrid.HorizontalAlignment = HorizontalAlignment.Left;


            ColumnDefinition colDef1 = new ColumnDefinition();
            ColumnDefinition colDef2 = new ColumnDefinition();
            ColumnDefinition colDef3 = new ColumnDefinition();
            ColumnDefinition colDef4 = new ColumnDefinition();
            ColumnDefinition colDef5 = new ColumnDefinition();
            mygrid.ColumnDefinitions.Add(colDef1);
            mygrid.ColumnDefinitions.Add(colDef2);
            mygrid.ColumnDefinitions.Add(colDef3);
            mygrid.ColumnDefinitions.Add(colDef4);
            mygrid.ColumnDefinitions.Add(colDef5);

            RowDefinition rowDefinition1 = new RowDefinition();
            RowDefinition rowDefinition2 = new RowDefinition();
            mygrid.RowDefinitions.Add(rowDefinition1);
            mygrid.RowDefinitions.Add(rowDefinition2);

            ImageBrush im = new ImageBrush();
            im.ImageSource = new BitmapImage(new Uri(product.Photo, UriKind.RelativeOrAbsolute));
            var panel2 = new DockPanel();
            panel2.Background = im;
            Grid.SetRow(panel2, 0);
            Grid.SetColumn(panel2, 0);
            Grid.SetRowSpan(panel2, 2);

            var textBlock = new TextBlock();
            textBlock.Text = $"{product.Discription.ToString()}  {product.Model.ToString()}";
            textBlock.FontSize = 20;
            textBlock.FontFamily = new FontFamily("Gabriola");
            Grid.SetRow(textBlock, 0);
            Grid.SetColumn(textBlock, 1);
            Grid.SetColumnSpan(textBlock, 3);



            var textBlock2 = new TextBlock();
            textBlock2.Text = product.Price.ToString();
            textBlock2.FontSize = 20;
            textBlock2.FontFamily = new FontFamily("Gabriola");
            Grid.SetRow(textBlock2, 0);
            Grid.SetColumn(textBlock2, 4);
             
            var but = new Button();
            but.Content = "Видалити";
            but.Click += but_Click;
            Grid.SetRow(but, 1);
            Grid.SetColumn(but, 4);



            but.Tag = product.Id;
            mygrid.Children.Add(panel2);
            mygrid.Children.Add(textBlock);
            mygrid.Children.Add(textBlock2);
            mygrid.Children.Add(but);

            return mygrid;

        }

        private void but_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
}
