using Dll.Context;
using Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Dll.Repository
{
    public class OrderRepository : IRepository<Order>
    {
        private readonly CompStoreContext context;
        public OrderRepository(CompStoreContext compStoreContext)
        {
            context = compStoreContext;
        }
        public void Create(Order data)
        {
            context.Orders.Add(data);
            context.SaveChanges();
        }


        public void Delete(int id)
        {
            var data = context.Categorys.First(x => x.Id == id);
            context.Categorys.Remove(data);
            context.SaveChanges();
        }

        //public IEnumerable<Order> GetFromCondition(Expression<Func<Order, bool>> condition) => context.Orders.Where(condition).Include(nameof(Order.Customer)).Include(nameof(Order.Product)).ThenInclude(nameof(Order.Product.Brand)).ToList();
        public IEnumerable<Order> GetFromCondition(Expression<Func<Order, bool>> condition) => context.Orders.Where(condition).Include(nameof(Order.Customer)).Include(x => x.Product).ThenInclude(x => x.Brand).ToList();



        public Order GetValue(int id) => context.Orders.First(x => x.Id == id);


        public void Update(int id, Order data)
        {
            var oldData = context.Orders.First(x => x.Id == id);
            oldData.DateOrder = data.DateOrder;
            oldData.Status = data.Status;

            context.Entry(oldData).State = EntityState.Modified;

            context.SaveChanges();
        }
    }
}
