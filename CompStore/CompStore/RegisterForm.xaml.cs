using Bll.Service;
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
    /// Interaction logic for RegisterForm.xaml
    /// </summary>
    public partial class RegisterForm : Window
    
    {
        private readonly CustomersService customersService;
       public Customer Customer { get; set; }
        public RegisterForm(CustomersService _customersService)
        {
            customersService = _customersService;
            Customer = new Customer();
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Customer.Name = NameTextBox.Text;
            Customer.SurName = SurNameTextBox.Text;
            Customer.Login = LoginTextBox.Text;
            Customer.Email = MailTextBox.Text;
            Customer.Password = PassTextBox.Text;
            int phone;
            int.TryParse(TelTextBox.Text, out phone);
            Customer.Phone = phone;
            Customer.PhotoPath = PhotoTextBox.Text;
            Customer.TypeUser = TypeUser.Client;
           var temp = customersService.GetFromCondition(x=>x.Login == LoginTextBox.Text);
            if (temp.Count==0)
            {
                customersService.Create(Customer);
                this.Close();
            }
            else { MessageBox.Show($"Користувач {Customer.Login} існує"); }
            

        }
    }
}
