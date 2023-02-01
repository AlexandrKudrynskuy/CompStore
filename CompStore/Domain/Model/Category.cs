using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class Category
    {
        public int Id { get; set; }
        public string Name{ get; set; }
        public List<Product> Products { get; set; }
        public int Count
        {
            get
            {
                if (Products != null)
                {
                    return Products.Count;
                }
                return 0;
            }
            set
            {
                if (Products != null)

                    Count = Products.Count;
            }
        }
    }
}
