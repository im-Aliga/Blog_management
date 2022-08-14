using Blog_management.AplicationLogic.Validations;
using Blog_management.DataBase.Model;
using Blog_management.DataBase.Reposity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog_management.AplicationLogic.Services
{
    public class BlogService
    {
        public static BlogReposity blogRepo = new BlogReposity();

        public static CommentReposity commentRepo = new CommentReposity();
        public static void ShowBlogsWithComment()
        {
            BlogReposity blogRepo = new BlogReposity();
            CommentReposity commentRepo = new CommentReposity();
            List<Blog> blogs = blogRepo.GetAll();
            int counter = 1;
            foreach (Blog blog in blogs)
            {
                if (blog.BlogStatus == BlogStatus.Approve)
                {
                    Console.WriteLine(blog.BlogInfo());

                    foreach (BlogComments comment in commentRepo.GetAll(c => c.WhichBlog == blog))
                    {

                        Console.WriteLine($"{counter}{"."}  { comment.GetCommentInfo()}");
                        counter++;
                        Console.WriteLine(" ");
                    }
                }


            }

        }
        public static void FindBlogByFilter()
        {
            Console.WriteLine("/Title");
            Console.WriteLine("/Lastname");
            while (true)
            {
                Console.Write("Enter suitable command: ");
                string command = Console.ReadLine();
                if (command == "/Title")
                {
                    Console.WriteLine(" ");
                    Console.Write("Please enter blog's title: ");
                    string title = Console.ReadLine();
                    int count = 1;
                    foreach (Blog blog in blogRepo.GetAll())
                    {
                        if (blog.BlogTitle == title && blog.BlogStatus == BlogStatus.Approve)
                        {
                            Console.WriteLine(blog.BlogInfo());

                            foreach (BlogComments comment in commentRepo.GetAll(c => c.WhichBlog == blog))
                            {


                                Console.WriteLine($"{count}{"."}  { comment.GetCommentInfo()}");
                                count++;

                            }
                        }
                        else
                        {
                            Console.WriteLine("this title blog's Not found");
                            break;

                        }
                    }
                }
                else if (command == "/Lastname")
                {
                    Console.Write("Please enter owener's lastname: ");
                    string lastName = Console.ReadLine();
                    int count = 1;
                    foreach (Blog blog in blogRepo.GetAll())
                    {
                        if (blog.Owner.LastName == lastName && blog.BlogStatus == BlogStatus.Approve)
                        {
                            Console.WriteLine(blog.BlogInfo());

                            foreach (BlogComments comment in commentRepo.GetAll(c => c.WhichBlog == blog))
                            {

                                Console.WriteLine($"{count}{"."}  { comment.GetCommentInfo()}");
                                count++;

                            }
                        }
                        else
                        {
                            Console.WriteLine("this lastname's blog not found");
                            break;
                        }

                    }
                }
                else
                {
                    Console.WriteLine("Command not found please check");
                    Console.WriteLine(" ");
                }
            }


        }
        public static void FindBlogByCode()
        {
           

                Console.Write("Please enter blog code: ");
                string blogCode = Console.ReadLine();
                Blog blog = blogRepo.GetById(blogCode);
                int count = 1;


                if (blog != null && blog.BlogStatus == BlogStatus.Approve)
                {
                    Console.WriteLine(blog.BlogInfo());
                    foreach (BlogComments comment in commentRepo.GetAll(c => c.WhichBlog == blog))
                    {
                        Console.WriteLine($"{count}" + comment.GetCommentInfo());
                        count++;


                    }
                }
                else
                {
                    Console.WriteLine("blog code not found");
                }
            




        }
        public static string GetComment()
        {
            Console.Write("Please enter comment content: ");
            string commentContent = Console.ReadLine();
            while (!CommentValidations.IsValidContent(commentContent))
            {
                Console.Write("Please enter comment content again: ");
                commentContent = Console.ReadLine();
            }
            return commentContent;
        }
        public static string GetBlogTitle()
        {
            Console.Write("Please enter blog title: ");
            string blogTitle = Console.ReadLine();
            while (!BlogValidations.IsValidTitle(blogTitle))
            {
                Console.WriteLine("Please enter blog title again: ");
                blogTitle = Console.ReadLine();
            }
            return blogTitle;

        }
        public static string GetBlogContent()
        {
            Console.Write("Please enter blog content: ");
            string blogContent = Console.ReadLine();
            while (!BlogValidations.IsValidContent(blogContent))
            {
                Console.WriteLine("Please enter blog content again: ");
                blogContent = Console.ReadLine();
            }
            return blogContent;

        }

    }
}
