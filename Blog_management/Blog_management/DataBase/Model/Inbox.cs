using Blog_management.DataBase.Model.Common;
using Blog_management.DataBase.Reposity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog_management.DataBase.Model
{
    public class Inbox : Entity<int>
    {
        public string Notfication { get; set; }

        public User User { get; set; }

        public Inbox(string notification, User user, int? id = null)
        {
            Notfication = notification;
            User = user;
            if (id != null)
            {
                Id = id.Value;
            }
            else
            {
                Id = UserReposity.IdCounter;
            }
        }
    }
}
