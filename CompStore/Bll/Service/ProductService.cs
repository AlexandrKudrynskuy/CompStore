using Dll.Repository;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Bll.Service
{
    public class ProductService
    {
        private IRepository<Product> repository;
        
        public ProductService(ProductRepository productRepository)
        {
            repository = productRepository;
        }
        public void Create(Product product)=>repository.Create(product);
        public void Delete(int id)=>repository.Delete(id);
        public void Update(int id, Product product)=>repository.Update(id, product);
        public Product GetValue(int id)=>repository.GetValue(id);
        public List<Product> GetFromCondition(Expression<Func<Product, bool>> conditionExpression)=>repository.GetFromCondition(conditionExpression).ToList();
    }
}
