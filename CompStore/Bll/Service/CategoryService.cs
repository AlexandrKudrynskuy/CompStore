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
    public class CategoryService
    {
        private IRepository<Category> repository;

        public CategoryService(CategoryRepository categoryRepository)
        {
            repository = categoryRepository;
        }

        public void Create(Category category) => repository.Create(category);

        public void Delete(int id) => repository.Delete(id);
        public void Update(int id, Category category) => repository.Update(id, category);
        public Category GetValue(int id) => repository.GetValue(id);
        
        public List<Category> GetFromCondition(Expression<Func<Category, bool>> conditionExpression) => repository.GetFromCondition(conditionExpression).ToList();
    }

}
