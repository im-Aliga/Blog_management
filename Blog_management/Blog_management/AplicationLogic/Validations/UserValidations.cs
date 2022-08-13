﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Blog_management.AplicationLogic.Validations
{
    internal class UserValidations
    {
        public static bool IsValidFirstName(string firstName)
        {
            Regex regex = new Regex(@"^(?=[A-Z]{1})([A-Za-z]{3,30})$");

            if (regex.IsMatch(firstName))
            {
                return true;
            }

            Console.WriteLine("The name you entered is incorrect, make sure the name contains only letters, the first letter is capitalized, and the length is greater than 3 and less than 30.");

            return false;
        }
        public static bool IsValidLastName(string lastName)
        {
            Regex regex = new Regex(@"^(?=[A-Z]{1})([A-Za-z]{3,30})$");

            if (regex.IsMatch(lastName))
            {
                return true;
            }

            Console.WriteLine("The last name you entered is incorrect, make sure that the last name contains only letters, the first letter is capitalized, and the length is greater than 3 and less than 30.");
            return false;
        }
        public static bool IsValidEmail(string email)
        {
            Regex regex = new Regex(@"^[A-Za-z0-9]{3,20}@code\.edu\.az$");

            if (regex.IsMatch(email))
            {
                return true;
            }
            Console.WriteLine("Receent can consist of only letters and numbers, the total length can be min 10 max 30,");
            Console.WriteLine("Separator - there must be an @ in between");
            Console.WriteLine("Domain - can only end with 'code.edu.az'");



            return false;
        }
    }
}
