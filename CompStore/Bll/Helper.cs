using Bll.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Bll
{
    public static class Helper
    {
        public static string PhotoPathUser { get; set; }
        public static string PhotoPathBrand { get; set; }
        public static string PhotoPathProduct { get; set; }

   

        static Helper() 
        {
            PhotoPathUser = "D:\\Compstore\\PhotoPathUser";
            PhotoPathBrand = "D:\\Compstore\\PhotoPathBrand";
            PhotoPathProduct = "D:\\Compstore\\PhotoPathProduct";
            if (!Directory.Exists(PhotoPathUser))
            {
                Directory.CreateDirectory(PhotoPathUser);
            }
            if (!Directory.Exists(PhotoPathBrand))
            {
                Directory.CreateDirectory(PhotoPathBrand);
            }

            if (!Directory.Exists(PhotoPathProduct))
            {
                Directory.CreateDirectory(PhotoPathProduct);
            }
        }
       
        public static bool IsCorectLogin(this string str)
        {
            string patern = @"^[A-z0-9_-]{3,40}$";
            var regex = new Regex(patern);
            var match = regex.Matches(str);
            if (match.Count == 1)
            {
                return true;
            }
            return false;

        }
        public static bool IsCorectPassword(this string str)
        {
            string patern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[^a-zA-Z0-9])\S{8,16}$";
            var regex = new Regex(patern);
            var match = regex.Matches(str);
            if (match.Count == 1)
            {
                return true;

            }
            return false;
        }
        public static bool IsCorectName(this string str)
        {
            string patern = @"^([А-ЯІ]{1}[а-яі]{1,23}|[A-Z]{1}[a-z]{1,23})$";
            var regex = new Regex(patern);
            var match = regex.Matches(str);
            if (match.Count == 1)
            {
                return true;

            }
            return false;


        }
    }
}
