using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.Products
{
    public  class Speaker:Product
    {
        public int Power { get; set; }
        public int Width { get; set; }
        public int Heigth { get; set; }
        public string Color { get; set; }

    }
}
