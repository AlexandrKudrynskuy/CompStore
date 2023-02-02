using Dll.Repository;
using Domain.Model;
using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Text.Json;
using System.Reflection.Metadata;

namespace Bll.Service
{
    public class CustomersService
    {
        private IRepository<Customer> repository;

        public CustomersService(CustomerRepository customerRepository)
        {
            repository = customerRepository;
        }

        public void Create(Customer customer) => repository.Create(customer);

        public void Delete(int id) => repository.Delete(id);
        public void Update(int id, Customer customer) => repository.Update(id, customer);
        public Customer GetValue(int id) => repository.GetValue(id);
        public List<Customer> GetFromCondition(Expression<Func<Customer, bool>> conditionExpression) => repository.GetFromCondition(conditionExpression).ToList();
        public Customer Login(string username, string password)
        {
            Customer customer=new Customer();
            var result = GetFromCondition(x => x.Login == username && x.Password == password);
            if (result.Count() > 0)
            {
                customer = result.FirstOrDefault(x =>x.Login == username);
                File.WriteAllText("user.txt", username);

            }
            else
            {
                customer = null;
            }
            return customer;
        }
    }
}
