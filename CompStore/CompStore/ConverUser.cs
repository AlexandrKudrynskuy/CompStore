using Domain.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace CompStore
{
    public class ConverUser : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            if (value != null)
            {
                TypeUser typeUser = (TypeUser)Enum.Parse(typeof(TypeUser), value.ToString());
                switch (typeUser)
                {
                    case TypeUser.Admin:
                        {
                            return "Адмін";
                            break;
                        }
                    case TypeUser.Client:
                        {
                            return "Кліент";
                            break;
                        }
                    default:
                        {
                            return "невідомо";
                            break;
                        }
                }

            }
            return 1;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
