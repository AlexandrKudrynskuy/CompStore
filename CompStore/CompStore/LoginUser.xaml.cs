using Bll.Service;
using Domain.Model;
using Microsoft.Extensions.DependencyInjection;
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
    /// Interaction logic for LoginUser.xaml
    /// </summary>
    public partial class LoginUser : Window
    {
        private readonly CustomersService customersService;
        
        public LoginUser(CustomersService _customersService)
        {
            customersService = _customersService;
   
            InitializeComponent();
        }

        private void LoginU_Click(object sender, RoutedEventArgs e)
        {
            var customer = customersService.Login(LoginTextBox.Text, PasswordPaswordBox.Password);
            if (customer != null && customer.TypeUser == TypeUser.Client)
            {
                this.Close();
                var wind = App.provider.GetService<StoreWindow>();
                wind.ShowDialog();
            }
            else
            {
                MessageBox.Show("Логін або пароль неправильний, або ви адміністратор");
            }
        }

        private void RegistrUser_Click(object sender, RoutedEventArgs e)
        {
            var wind = App.provider.GetService<RegisterForm>();
            wind.ShowDialog();
        }
    }
}
