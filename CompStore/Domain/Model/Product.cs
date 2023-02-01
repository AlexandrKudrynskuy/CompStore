using Domain.Model.Products;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class Product
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }
        public Category Category { get; set; }

        public Brand Brand { get; set; }

        public string Model { get; set; }

        public double Price { get; set; }
        public int Count { get; set; }
        public string Discription { get; set; }
        public string Photo { get; set; }

        public int CategoryID { get; set; }
        public int BrandId { get; set; }

        public List<Order> Orders { get; set; }

    }
}
