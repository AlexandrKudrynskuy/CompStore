using Dll.Context;
using Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Dll.Repository
{
    public class CustomerRepository:IRepository<Customer>
    {
        private readonly CompStoreContext context;
        public CustomerRepository(CompStoreContext compStoreContext)
        {
            context = compStoreContext;
        }
        public void Create(Customer data)
        {
            context.Customers.Add(data);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var data = context.Customers.First(x => x.Id == id);
            context.Customers.Remove(data);
            context.SaveChanges();
        }

        public IEnumerable<Customer> GetFromCondition(Expression<Func<Customer, bool>> condition) => context.Customers.Where(condition).Include(nameof(Customer.Orders)).ToList();




        public Customer GetValue(int id) => context.Customers.First(x => x.Id == id); 
        
        

        public void Update(int id, Customer data)
        {
            var oldData = context.Customers.First(x => x.Id == id);
            oldData.Name = data.Name;
            oldData.SurName = data.SurName;
            oldData.Email = data.Email;
            oldData.Phone = data.Phone;
            oldData.Login = data.Login;
            oldData.Password = data.Password;
            oldData.TypeUser = data.TypeUser;
            oldData.PhotoPath = data.PhotoPath;


            context.Entry(oldData).State = EntityState.Modified;
            context.SaveChanges();
        }
    
    }
}
