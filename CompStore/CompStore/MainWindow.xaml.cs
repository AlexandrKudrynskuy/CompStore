using Dll.Context;
using Microsoft.EntityFrameworkCore;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CompStore
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private CompStoreContext context;
        public MainWindow()
        {
            var conectionOption = new DbContextOptionsBuilder<CompStoreContext>().UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=CompStore;Integrated Security=True;").Options;
            context = new CompStoreContext(conectionOption);
            InitializeComponent();
        }
    }
}
