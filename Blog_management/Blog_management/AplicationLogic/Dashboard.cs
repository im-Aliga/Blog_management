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
        }

    }
}
