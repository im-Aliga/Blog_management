using Blog_management.DataBase.Model;
using Blog_management.DataBase.Reposity;
using Blog_management.DataBase.Reposity.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog_management.AplicationLogic
{
    public static partial class Dashboard
    {
        public static User CurrentUser { get; set; }

        public static void AdminPAnel()
        {
            Reposity<User, int> baserepo = new Reposity<User, int>();

            BlogReposity blogRepo = new BlogReposity();

            InboxReposity inboxRepo = new InboxReposity();

            Admin admin1 = (Admin)UserReposity.GetUerByEmail(CurrentUser.Email);

            Console.WriteLine(admin1.GetInfo());
            string[] commands = { "/add-user",
                                  "/update-user",
                                  "/reports",
                                  "/remove-user",
                                  "/add-admin",
                                  "/show-admins",
                                  "/update-admin ",
                                  "/remove-admin",
                                  "/show-users",
                                  "/approve-blog",
                                  "/reject-blog",
                                  "/show-auditing-blogs",
                                  "/log out" };

            foreach (string command in commands)
            {
                Console.WriteLine(command);
            }
            while(true)
            {

                Console.WriteLine("");
                Console.Write("Please enter command : ");
                string command = Console.ReadLine();
                if (command == "/add-user")
                {
                    Autentication.Resgister();
                }

            }


        }

    }
}
