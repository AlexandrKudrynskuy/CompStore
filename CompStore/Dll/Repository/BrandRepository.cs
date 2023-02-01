using Dll.Context;
using Domain.Model;
using Domain.Model.Products;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Dll.Repository
{
    public class BrandRepository : IRepository<Brand>
    {
        private readonly CompStoreContext context;
        public BrandRepository(CompStoreContext compStoreContext)
        {
            context = compStoreContext;
        }
        public void Create(Brand data)
        {
            context.Brands.Add(data);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var data = context.Brands.First(x => x.Id == id);
            context.Brands.Remove(data);
            context.SaveChanges();
        }

        public IEnumerable<Brand> GetFromCondition(Expression<Func<Brand, bool>> condition) => context.Brands.Where(condition).Include(nameof(Brand.Products)).ToList();




        public Brand GetValue(int id)=> context.Brands.First(x => x.Id == id);
        

        public void Update(int id, Brand data)
        {
            var oldData = context.Brands.First(x => x.Id == id);
            oldData.Name = data.Name;
            oldData.PhotoLogo = data.PhotoLogo;

            context.Entry(oldData).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
