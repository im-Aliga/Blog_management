using Blog_management.DataBase.Model.Common;
using Blog_management.DataBase.Reposity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog_management.DataBase.Model
{
    public class Blog : Entity<string>
    {
        public User Owner { get; set; }

        public string BlogTitle { get; set; }

        public string BlogContent { get; set; }

        public BlogStatus BlogStatus { get; set; }

        public Blog(User owner, string blogTitle, string blogContent, BlogStatus blogStatus, string id = null)
        {
            Owner = owner;
            BlogTitle = blogTitle;
            BlogContent = blogContent;
            BlogStatus = blogStatus;
            if (id != null)
            {
                Id = id;
            }
            else
            {
                Id = BlogReposity.BlogCode;
            }

        }

        public string BlogInfo()
        {
            return RegistrationTime.ToString("dd/MM/yyyy") + " " + Id + " " + Owner.FirstName + " " + Owner.LastName + "\n" + "===" + BlogTitle + "===" + " \n" + BlogContent + "\n";
        }
    }
}
