using Blog_management.DataBase.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog_management.DataBase.Reposity
{
    public class CommentReposity : Common.Reposity<BlogComments, int>
    {
        public static BlogReposity blogRepo = new BlogReposity();
        static CommentReposity()
        {

            DBcontect.Add(new BlogComments(blogRepo.GetById("BL11111"), UserReposity.GetUerByEmail("ayroali@gmail.com"), "Beli beli tamamile raziyam"));
            DBcontect.Add(new BlogComments(blogRepo.GetById("BL11111"), UserReposity.GetUerByEmail("haci@gmail.com"), "he eledi"));
            DBcontect.Add(new BlogComments(blogRepo.GetById("3"), UserReposity.GetUerByEmail("haci@gmail.com"), "iajfhkkafhfskj e"));


        }

        //public static void DeleteComment(Blog blog)
        //{
        //    foreach(BlogComments comment in DBcontect)
        //    {
        //        if(comment.WhichBlog==blog)
        //        {
        //            DBcontect.Remove(comment);
        //        }
        //    }
        //}


    }
}
