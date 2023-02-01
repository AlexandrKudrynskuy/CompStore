using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.Products
{
    public enum PrinterType
    {
        NoSet=-1,
        Laser,
        Jet,
        Matrix,
    }
    
    public class MFU: Product
    {
 
        public PrinterType PrinterType { get; set; }
        public string DPI { get; set; }
        public  int ColorCount { get; set; }
        public bool HasWiFi { get; set; }
      
    }
}
