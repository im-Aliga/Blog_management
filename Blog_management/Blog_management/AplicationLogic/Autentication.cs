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
        public static void Resgister()
        {
            string firstName = GetName();
            string lastName = GetLastname();
            string email = GetEmail();
            string password = GetPassword();

            if (UserValidations.IsValidFirstName(firstName) &
                UserValidations.IsValidLastName(lastName) &
                UserValidations.IsValidEmail(email) &
                UserValidations.IsValidPassword(password))
            {
                User user = UserReposity.AddUser(firstName, lastName, email, password);
                Console.WriteLine($"User added to system, his/her details are : {user.GetInfo()}");

            }

        }
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
        public static string GetLastname()
        {

            Console.Write("Please enter user's last name :");
            string lastname = Console.ReadLine();
            while (!UserValidations.IsValidLastName(lastname))
            {
                Console.WriteLine("Please enter correct user's lastname : ");
                lastname = Console.ReadLine();
            }
            return lastname;
        }
        public static string GetEmail()
        {
            Console.Write("Please enter user's email : ");
            string email = Console.ReadLine();
            while (!UserValidations.IsValidEmail(email) && !UserValidations.IsUserExitsUnique(email))
            {
                Console.Write("Please enter correct user's email : ");
                email = Console.ReadLine();
            }
            return email;
        }
        public static string GetPassword()
        {
            Console.Write("Please enter user's password : ");
            string password = Console.ReadLine();

            while (!UserValidations.IsValidPassword(password))
            {
                Console.WriteLine("Please enter again user's password correctly : ");
                password = Console.ReadLine();
            }
            Console.WriteLine("Please enter again user's password : ");
            string confirmpassword = Console.ReadLine();
            while (!UserValidations.IsPasswordsMatch(password, confirmpassword))
            {
                Console.WriteLine("No match passwords");
                confirmpassword = Console.ReadLine();
            }
            return password;

        }

        public static void Login()
        {
            Console.Write("Please enter Email:  ");
            string email = Console.ReadLine();
            Console.Write("Please enter password:  ");
            string password = Console.ReadLine();
            if (UserReposity.GetUserByEmailAndPassword(email, password))
            {
                User user = UserReposity.GetUerByEmail(email);
                Dashboard.CurrentUser = user;
                if (user is Admin)
                {
                    Dashboard.AdminPanel();
                }
                if (user is User)
                {
                    Dashboard.UserPanel(email);
                }

            }


        }

    }

}
