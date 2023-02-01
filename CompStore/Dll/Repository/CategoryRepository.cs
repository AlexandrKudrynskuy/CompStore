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
    public class CategoryRepository : IRepository<Category>
    {
        private readonly CompStoreContext context;
        public CategoryRepository(CompStoreContext compStoreContext)
        {
            context = compStoreContext;
        }
        public void Create(Category data)
        {
            context.Categorys.Add(data);
            context.SaveChanges();
        }

  
        public void Delete(int id)
        {
            var data = context.Categorys.First(x => x.Id == id);
            context.Categorys.Remove(data);
            context.SaveChanges();
        }

        public IEnumerable<Category> GetFromCondition(Expression<Func<Category, bool>> condition) => context.Categorys.Where(condition).Include(nameof(Category.Products));




        public Category GetValue(int id) => context.Categorys.First(x => x.Id == id);


        public void Update(int id, Category data)
        {
            var oldData = context.Categorys.First(x => x.Id == id);
            oldData.Name = data.Name;

            context.Entry(oldData).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
