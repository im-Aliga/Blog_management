using Blog_management.AplicationLogic.Services;
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
            while (true)
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
                else if (command == "/add-admin")
                {
                    Admin admin = new Admin(Autentication.GetName(), Autentication.GetLastname(), Autentication.GetEmail(), Autentication.GetPassword());
                    baserepo.Add(admin);
                }
                else if (command == "/show-admins")
                {
                    UserReposity.ShowAdmins();
                }
                else if (command == "/update-admin")
                {
                    Console.Write("Please enter admin's email");
                    string email = Console.ReadLine();
                    User admin = UserReposity.GetUerByEmail(email);
                    if (admin.Email == CurrentUser.Email)
                    {
                        Console.WriteLine("This email is your's email");
                    }
                    else if (email == null)
                    {
                        Console.WriteLine("This email is not found");
                    }
                    else if (admin is Admin)
                    {
                        Admin updateAdmin = new Admin(Autentication.GetName(), Autentication.GetLastname());
                        UserReposity.UpdateForAdmin(email, updateAdmin);
                        Console.WriteLine("Admin has been updated");

                    }
                    else if (admin is User)
                    {
                        Console.WriteLine("This email is user's email");
                    }
                    else
                    {
                        Console.WriteLine("Not Found");
                    }

                }
                else if (command == "/remove-admin")
                {
                    Console.Write("Please enter admin's mail : ");
                    string email = Console.ReadLine();
                    User admin = UserReposity.GetUerByEmail(email);
                    if (admin.Email == CurrentUser.Email)
                    {
                        Console.WriteLine("This is your's email");
                    }
                    else if (admin == null)
                    {
                        Console.WriteLine("Admin is not found");
                    }
                    else if (admin is User)
                    {
                        Console.WriteLine("This is user's email");
                    }
                    else if (admin is Admin)
                    {
                        baserepo.Delete(admin);
                        User user = new User(admin.FirstName, admin.LastName, admin.Email, admin.Password, admin.Id);
                        baserepo.Add(user);
                        Console.WriteLine("Admin has been romoved!");
                    }



                }
                else if (command == "/log out")
                {
                    Program.Main(new string[] { });
                    break;
                }
                else if (command == "/show-users")
                {
                    UserReposity.ShowUsers();

                }
                else if (command == "/show-auditing-blogs")
                {
                    List<Blog> blogs = blogRepo.GetAll();
                    foreach (Blog blog in blogs)
                    {
                        if (blog.BlogStatus == BlogStatus.Created)
                        {
                            Console.WriteLine(blog.BlogInfo());
                        }
                    }

                }
                else if (command == "/approve-blog")
                {
                    Console.Write("Please enter blog's BlogCode: ");
                    string blogCode = Console.ReadLine();
                    Blog blog = blogRepo.GetById(blogCode);
                    if (blog != null)
                    {
                        if (blog.BlogStatus == BlogStatus.Created)
                        {

                            blog.BlogStatus = BlogStatus.Approve;
                            Inbox message = new Inbox($"This blog {blog.Id} Approved by Admin", blog.Owner);
                            inboxRepo.Add(message);
                            Console.WriteLine("Blog has been aproved");

                        }
                    }
                    else
                    {
                        Console.WriteLine("not found");
                    }

                }
                else if (command == "/reject-blog")
                {
                    Console.WriteLine("Please enter blog's BlogCode: ");
                    string blogCode = Console.ReadLine();
                    Blog blog = blogRepo.GetById(blogCode);
                    if (blog != null)
                    {

                        if (blog.BlogStatus == BlogStatus.Created)
                        {
                            blog.BlogStatus = BlogStatus.Approve;
                            Inbox message = new Inbox($"This blog {blog.Id} Rejected by Admin", blog.Owner);
                            inboxRepo.Add(message);
                            Console.WriteLine("Blog has been Rejected");

                        }
                    }
                    else
                    {
                        Console.WriteLine("not found");
                    }



                }
                else
                {
                    Console.WriteLine("Command not found");
                }




            }


        }

    }

    public static partial class Dashboard
    {
        public static void UserPanel(string email)
        {
            CommentReposity commentRepo = new CommentReposity();

            BlogReposity blogRepo = new BlogReposity();

            InboxReposity inboxRepo = new InboxReposity();

            User user = UserReposity.GetUerByEmail(email);

            Console.WriteLine($"user succesfully joined : {user.GetInfo()}");
            string[] commands = { "/update-info",
                                      "/report-user",
                                      "/inbox",
                                      "/add-comment",
                                      "/blogs",
                                      "/add-blog",
                                      "/delete-blog",

                                      "/log out" };

            foreach (string command in commands)
            {
                Console.WriteLine(command);
            }
            while (true)
            {
                Console.WriteLine("");

                Console.Write("Please enter command: ");

                string command = Console.ReadLine();

                if (command == "/update-info")
                {
                    if (user.Email == CurrentUser.Email)
                    {
                        User updateUser = new User(Autentication.GetName(), Autentication.GetLastname());
                        UserReposity.UpdateForUser(email, updateUser);
                        Console.WriteLine("update succesfully");

                    }
                    else
                    {
                        Console.WriteLine("This email is not your's");
                    }
                }
                else if (command == "/report-user")
                {

                    Console.Write("Please enter user's email :");
                    string reportEmail = Console.ReadLine();
                    Console.Write("Please enter report's content");
                    string content = Console.ReadLine();


                    User to = UserReposity.GetUerByEmail(reportEmail);
                    if (to == null)
                    {
                        Console.WriteLine("This user not found");
                    }
                    else if (to == CurrentUser)
                    {
                        Console.WriteLine("This account is your's acoount");
                    }
                    ReportReposity.Add(CurrentUser, to, content);
                    Console.WriteLine("report sended succesfully");
                }
                else if (command == "/log out")
                {
                    Program.Main(new string[] { });

                }
                else if (command == "/add-comment")
                {
                    Console.Write("Please enter blog code: ");
                    string blogCode = Console.ReadLine();
                    BlogReposity blogReposity = new BlogReposity();
                    Blog blog = blogReposity.GetById(blogCode);
                    if (blog != null)
                    {
                        BlogComments comments = new BlogComments(blog, CurrentUser, BlogService.GetComment());
                        commentRepo.Add(comments);
                        Inbox inbox = new Inbox($"this blog code'{blog.Id} {blog.Owner.FirstName} {blog.Owner.LastName} added comment", blog.Owner);
                        inboxRepo.Add(inbox);
                        Console.WriteLine("Comment added succesfully");

                    }
                    else
                    {
                        Console.WriteLine("Blog Not Found");
                    }

                }
            }
        }

    }
}
