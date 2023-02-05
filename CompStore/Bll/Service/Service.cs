using Domain.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.Service
{
    public class Service
    {
        private readonly ProductService productService;
        private readonly CustomersService customersService;
        private readonly BrandService brandService;
        public ObservableCollection<Product> Products { get; set; }
        public ObservableCollection<Brand> Brands { get; set; }
        public ObservableCollection<Customer> Customers { get; set; }

        public Service(ProductService _productService, CustomersService _customersService, BrandService _brandService)
        {

            productService = _productService;
            customersService = _customersService;
            brandService = _brandService;
            Products = new ObservableCollection<Product>(productService.GetFromCondition(x=>x.Id>0));
            Brands = new ObservableCollection<Brand>(brandService.GetFromCondition(x=>x.Id>0));
            Customers = new ObservableCollection<Customer>(customersService.GetFromCondition(x=>x.Id>0));

        }
        public  void ClearFoto()
        {
            var FotoCustomers = Directory.GetFiles(Helper.PhotoPathUser);
            var PotoProducts = Directory.GetFiles(Helper.PhotoPathProduct);
            var FotoBrands = Directory.GetFiles(Helper.PhotoPathBrand);

            foreach (var file in FotoCustomers)
            {
                if (Customers.FirstOrDefault(x => x.PhotoPath == file) == null)
                {
                    File.Delete(file);
                }
            }


            foreach (var file in PotoProducts)
            {
                if (Products.FirstOrDefault(x => x.Photo== file) == null)
                {
                    File.Delete(file);
                }
            }


            foreach (var file in FotoBrands)
            {
                if (Brands.FirstOrDefault(x => x.PhotoLogo == file) == null)
                {
                    File.Delete(file);
                }
            }

        }
    }
}
