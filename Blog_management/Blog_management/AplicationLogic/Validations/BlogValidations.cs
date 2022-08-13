using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog_management.AplicationLogic.Validations
{
    internal class BlogValidations
    {
        public static bool IsValidTitle(string title)
        {
            if (title.Length >= 10 & title.Length <= 35)
            {
                return true;

            }
            Console.WriteLine("Title length sould be between 10 and 35");
            return false;
        }
    }
}
