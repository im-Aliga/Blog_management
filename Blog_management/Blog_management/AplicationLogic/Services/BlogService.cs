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

    }
}
