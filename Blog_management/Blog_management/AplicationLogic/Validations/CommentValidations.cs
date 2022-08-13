using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog_management.AplicationLogic.Validations
{
    internal class CommentValidations
    {
        public static bool IsValidContent(string content)
        {
            if (content.Length >= 10 & content.Length <= 35)
            {
                return true;
            }
            Console.WriteLine("Length sould be between 10 and 35");
            return false;
        }
    }
}
