using Blog_management.DataBase.Model.Common;
using Blog_management.DataBase.Reposity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog_management.DataBase.Model
{
    public class User : Entity<int>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public DateTime? UpdateAt { get; set; }

        public User(string firstname, string lastname, string email, string password, int? id = null)
        {
            FirstName = firstname;
            LastName = lastname;
            Email = email;
            Password = password;
            if (id != null)
            {
                Id = id.Value;
            }
            else
            {
                Id = UserReposity.IdCounter;
            }
        }

        public User(string firstname, string lastname)
        {
            FirstName = firstname;
            LastName = lastname;
        }

        public virtual string GetInfo()
        {
            return $"Hello user: {FirstName}:  {LastName}";

        }

        public virtual string GetUpdateInfo()
        {
            if (UpdateAt.HasValue)
            {
                return $"Update at: {UpdateAt.Value.ToString("dd/MM/yyyy")}";
            }
            else
            {
                return "Not yet updated";
            }
        }

        public virtual string GetUserInfoForAdmin()
        {

            return Id + " " + FirstName + " " + LastName + " " + Email + " ";
        }

    }
}
}
