using Dll.Repository;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Bll.Service
{
    public  class CustomersService
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
    }
}
