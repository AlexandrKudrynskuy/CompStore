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
    public class BrandService
    {
        private IRepository<Brand> repository;

        public BrandService(BrandRepository brandRepository)
        {
            repository = brandRepository;
        }

        public void Create(Brand brand) => repository.Create(brand);

        public void Delete(int id) => repository.Delete(id);
        public void Update(int id, Brand brand) => repository.Update(id, brand);
        public Brand GetValue(int id) => repository.GetValue(id);
        public List<Brand> GetFromCondition(Expression<Func<Brand, bool>> conditionExpression) => repository.GetFromCondition(conditionExpression).ToList();
    }
}
