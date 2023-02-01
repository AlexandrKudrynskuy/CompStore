using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public enum TypeUser
    { 
    MotType=-1,
    Admin,
    Client
    }
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public TypeUser TypeUser { get; set; }
        public string Email { get; set; }
        public long Phone { get; set; }
        public string PhotoPath { get; set; }

        public List<Order> Orders { get; set; }

    }
}
