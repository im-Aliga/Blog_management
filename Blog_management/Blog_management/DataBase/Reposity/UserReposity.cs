using Blog_management.DataBase.Model;
using Blog_management.DataBase.Reposity.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog_management.DataBase.Reposity
{
    public class UserReposity:Reposity<User, int>
    {
        private static int _idCounter;

        public static int IdCounter
        {
            get
            {
                _idCounter++;
                return _idCounter;
            }

        }
        static UserReposity()
        {
            DefaultData();
        }

        private static void DefaultData()
        {
            DBcontect.Add(new Admin("Ali", "Aliyev", "ayroali@gmail.com", "123321", 1));
            DBcontect.Add(new Admin("Ewqin", "Facizade", "E@gmail.com", "123321", 2));
            DBcontect.Add(new User("Ceyhun", "Hacizade", "haci@gmail.com", "123321", 3));
            DBcontect.Add(new User("Revan", "Mahmudov", "mahmud@gmail.com", "123321", 4));
        }
        public static User AddUser(string firstName, string lastName, string email, string password)
        {
            User user = new User(firstName, lastName, email, password, IdCounter);
            DBcontect.Add(user);
            return user;

        }
        public static User AddUser(string firstName, string lastName, string email, string password, int id)
        {
            User user = new User(firstName, lastName, email, password, id);
            DBcontect.Add(user);
            return user;
        }
        public static bool IsUserExitsByEmail(string email)
        {
            foreach (User user in DBcontect)
            {
                if (user.Email == email)
                {
                    return true;
                }
            }
            return false;
        }
        public static bool GetUserByEmailAndPassword(string email, string password)
        {
            foreach (User user in DBcontect)
            {
                if (Equals(user.Email, email) && Equals(user.Password, password))
                {
                    return true;
                }

            }
            return false;
        }
        public static User GetUserById(int id)
        {
            foreach (User user in DBcontect)
            {
                if (user.Id == id)
                {
                    return user;

                }
            }
            return null;
        }
        public static User GetUerByEmail(string email)
        {
            foreach (User user in DBcontect)
            {
                if (user.Email == email)
                {
                    return user;
                }
            }
            return null;
        }
    }
}
