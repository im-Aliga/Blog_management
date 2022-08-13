using Blog_management.AplicationLogic;
using Blog_management.AplicationLogic.Services;
using Blog_management.UI;
using System;

namespace Blog_management
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Design.TypeWrite(@"
 █     █░ ▒█████   ██▓     ▄████▄   ▒█████   ███▄ ▄███▓▓█████  ▐██▌ 
▓█░ █ ░█░▒██▒  ██▒▓██▒    ▒██▀ ▀█  ▒██▒  ██▒▓██▒▀█▀ ██▒▓█   ▀  ▐██▌ 
▒█░ █ ░█ ▒██░  ██▒▒██░    ▒▓█    ▄ ▒██░  ██▒▓██    ▓██░▒███    ▐██▌ 
░█░ █ ░█ ▒██   ██░▒██░    ▒▓▓▄ ▄██▒▒██   ██░▒██    ▒██ ▒▓█  ▄  ▓██▒ 
░░██▒██▓ ░ ████▓▒░░██████▒▒ ▓███▀ ░░ ████▓▒░▒██▒   ░██▒░▒████▒ ▒▄▄  
░ ▓░▒ ▒  ░ ▒░▒░▒░ ░ ▒░▓  ░░ ░▒ ▒  ░░ ▒░▒░▒░ ░ ▒░   ░  ░░░ ▒░ ░ ░▀▀▒ 
  ▒ ░ ░    ░ ▒ ▒░ ░ ░ ▒  ░  ░  ▒     ░ ▒ ▒░ ░  ░      ░ ░ ░  ░ ░  ░ 
  ░   ░  ░ ░ ░ ▒    ░ ░   ░        ░ ░ ░ ▒  ░      ░      ░       ░ 
    ░        ░ ░      ░  ░░ ░          ░ ░         ░      ░  ░ ░    
                          ░                                         
");

            Console.WriteLine("Commands:");

            string[] commands = { "/Register", "/Login", "/Show-blogs-with-comments", "/Show-filtered-blogs-with-comments", "/find-blog-by-code", "/Exit" };

            foreach (string showcommands in commands)
            {
                Console.WriteLine(showcommands);
            }

            while (true)
            {
                Console.WriteLine("");

                Console.Write("Enter command: ");

                string command = Console.ReadLine();

                if (command == commands[0])
                {
                    Autentication.Resgister();
                }

                else if (command == commands[1])
                {
                    Autentication.Login();
                }

                else if (command == commands[2])
                {
                    BlogService.ShowBlogsWithComment();
                }

                else if (command == commands[3])
                {
                    BlogService.FindBlogByFilter();
                }

                else if (command == commands[4])
                {
                    BlogService.FindBlogByCode();
                }

                else if (command == commands[5])
                {
                    break;
                }

                else
                {
                    Console.WriteLine("Command not found!");
                }




            }

        }
    }
}
