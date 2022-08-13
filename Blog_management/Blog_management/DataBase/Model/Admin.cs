using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog_management.DataBase.Model
{
    public class Admin : User
    {
        public Admin(string firstName, string lastName, string email, string password, int id)
            : base(firstName, lastName, email, password, id)
        {

        }

        public Admin(string firstName, string lastname, string email, string password)
            : base(firstName, lastname, email, password)
        {

        }

        public Admin(string firstName, string lastname)
            : base(firstName, lastname)
        {

        }

        public override string GetInfo()
        {
            return $"Hello Admin: {Id}:{FirstName}:{LastName}:{RegistrationTime}";
        }
    }
}
