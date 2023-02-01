using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.Products
{
    public class Laptop:Product
    {
        public int Hdd { get; set; }
        public int Ram { get; set; }
        public string Processor { get; set; }
    }
}
