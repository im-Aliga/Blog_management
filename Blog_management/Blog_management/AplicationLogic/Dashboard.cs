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
                else if (command == "/update-user")
                {
                    Console.Write("Please enter user's email: ");
                    string email = Console.ReadLine();
                    User user = UserReposity.GetUerByEmail(email);
                    if (user == null)
                    {
                        Console.WriteLine("User not found!");
                    }
                    else if (user is Admin)
                    {
                        Console.WriteLine("This email is admin's email");
                    }
                    User updateUser = new User(Autentication.GetName(), Autentication.GetLastname());
                    UserReposity.UpdateForUser(email, updateUser);
                    Console.WriteLine("user hass been update");

                }
                else if (command == "/reports")
                {
                    ReportReposity reportReposity = new ReportReposity();
                    List<Report> reports = reportReposity.GetAll();
                    if (reports != null)
                    {
                        int count = 1;
                        foreach (Report report in reports)
                        {
                            Console.WriteLine($"{count}." + report.GetInfo());
                            count++;
                        }
                    }
                    else
                    {
                        Console.WriteLine("empty");
                    }




                }
                else if (command == "/remove-user")
                {
                    Console.Write("Please enter user's email");
                    string email = Console.ReadLine();
                    User user = UserReposity.GetUerByEmail(email);
                    if (user == null)
                    {
                        Console.WriteLine("User is not found!");
                    }
                    else if (user is Admin)
                    {
                        Console.WriteLine("This email is Admin's email");
                    }
                    baserepo.Delete(user);
                    Console.WriteLine("user deleted succesfully");


                }

            }


        }

    }
}
