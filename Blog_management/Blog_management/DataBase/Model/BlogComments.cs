using Blog_management.DataBase.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog_management.DataBase.Model
{
    public class BlogComments : Entity<int>
    {
        public Blog WhichBlog { get; set; }

        public User From { get; set; }

        public string CommentContent { get; set; }

        public BlogComments(Blog whichBlog, User form, string commentContent, int? id = null)
        {
            WhichBlog = whichBlog;
            From = form;
            CommentContent = commentContent;
            if (id != null)
            {
                Id = id.Value;
            }
            else
            {
                Id = UserReposity.IdCounter;
            }


        }

        public string GetCommentInfo()
        {
            return RegistrationTime + " " + From.FirstName + " " + From.LastName + " " + CommentContent;
        }


    }
}
