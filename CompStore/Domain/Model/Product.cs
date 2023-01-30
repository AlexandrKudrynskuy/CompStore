using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class Product
    {
        public int Id { get; set; }
        public Category Category { get; set; }

        public Brand Brand { get; set; }
 
        public string Model { get; set; }

        public double Price { get; set; }
        public string Discription { get; set; }
        
        public int CategoryID { get; set; }
        public int BrandId { get; set; }

        public List<Order> Orders { get; set; }


    }
}
