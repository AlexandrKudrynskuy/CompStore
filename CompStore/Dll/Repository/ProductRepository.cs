using Dll.Context;
using Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Dll.Repository
{
    public class ProductRepository : IRepository<Product>
    {
        private readonly CompStoreContext context;
        public ProductRepository(CompStoreContext compStoreContext)
        {
            context = compStoreContext;
        }
        public void Create(Product data)
        {
            context.Products.Add(data);
            context.SaveChanges();
        }
        public void Delete(int id)
        {
            var data = context.Products.First(x => x.Id == id);
            context.Products.Remove(data);
            context.SaveChanges();
        }        
        public IEnumerable<Product> GetFromCondition(Expression<Func<Product, bool>> condition) => context.Products.Where(condition).ToList();
        public Product GetValue(int id) => context.Products.First(x => x.Id == id);
        public void Update(int id, Product data)
        {
            var oldData = context.Products.First(x => x.Id == id);
            oldData.Category = data.Category;
            oldData.Brand = data.Brand;
            oldData.Model = data.Model;
            oldData.Price = data.Price;
            oldData.Discription = data.Discription;
            oldData.CategoryID = data.CategoryID;
            oldData.BrandId = data.BrandId;
            oldData.Orders = data.Orders;
            oldData.BrandId = data.BrandId;
            context.Entry(oldData).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
