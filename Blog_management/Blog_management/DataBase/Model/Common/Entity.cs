using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog_management.DataBase.Model.Common
{
    public abstract class Entity<T>
    {
        public T Id { get; set; }
        public DateTime RegistrationTime { get; set; } = DateTime.Now;
    }
}
