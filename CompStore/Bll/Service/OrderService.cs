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
    public class OrderService
    {
        private IRepository<Order> repository;

        public OrderService(OrderRepository orderRepository)
        {
            repository = orderRepository;
        }

        public void Create(Order order) => repository.Create(order);

        public void Delete(int id) => repository.Delete(id);
        public void Update(int id, Order order) => repository.Update(id, order);
        public Order GetValue(int id) => repository.GetValue(id);
        public List<Order> GetFromCondition(Expression<Func<Order, bool>> conditionExpression) => repository.GetFromCondition(conditionExpression).ToList();
    }
}
