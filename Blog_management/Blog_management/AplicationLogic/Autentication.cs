using Blog_management.AplicationLogic.Validations;
using Blog_management.DataBase.Model;
using Blog_management.DataBase.Reposity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog_management.AplicationLogic
{
    public class Autentication
    {
        public static string GetName()
        {
            Console.Write("Please enter user's name : ");
            string firstName = Console.ReadLine();
            while (!UserValidations.IsValidFirstName(firstName))
            {
                Console.Write("Please enter correct user's name : ");
                firstName = Console.ReadLine();
            }
            return firstName;
        }
    }
}
