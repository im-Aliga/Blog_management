using Blog_management.DataBase.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog_management.DataBase.Reposity.Common
{
    public  class Reposity <TEntity,Tid>
        where TEntity : Entity<Tid>
    {
        protected static List<TEntity> DBcontect { get; set; } = new List<TEntity>();

        public TEntity Add(TEntity entry)
        {
            DBcontect.Add(entry);
            return entry;
        }
    }
}
