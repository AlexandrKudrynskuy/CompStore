using Domain.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace CompStore
{
    public class ConvertHeader : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Product product)
            {
                //if (parameter.ToString() == "name")
                //{ 
                //return nameof(Product.Brand.Name.ToString());
                //}
                //var s = nameof(Product.Brand.Name);

            }

            return nameof(Product.Brand.Name);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
