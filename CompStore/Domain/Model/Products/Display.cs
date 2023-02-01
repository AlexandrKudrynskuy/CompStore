using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.Products
{
    public class Display:Product
    {
        public double DiagonalSize { get; set; }
        public string Resolution { get; set; }
        public string Color { get; set; }
    }
}
