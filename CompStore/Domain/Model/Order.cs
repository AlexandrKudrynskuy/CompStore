using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime DateOrder { get; set; }
        public Customer Customer { get; set; }
        public Product Product { get; set; }
        public bool Status { get; set; }
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
  
    }
}
