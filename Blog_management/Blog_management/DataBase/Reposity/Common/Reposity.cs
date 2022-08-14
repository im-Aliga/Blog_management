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

        public List<TEntity> GetAll()
        {
            return DBcontect;
        }

        public List<TEntity> GetAll(Predicate<TEntity> predicate)
        {
            List<TEntity> entities = new List<TEntity>();
            foreach (TEntity entity in DBcontect)
            {
                if (predicate(entity))
                {
                    entities.Add(entity);
                }
            }
            return entities;
        }

        public TEntity Get(Predicate<TEntity> expression)
        {
            foreach (TEntity entry in DBcontect)
            {
                if (expression(entry))
                {
                    return entry;
                }
            }
            return null;
        }

        public TEntity GetById(Tid id)
        {
            foreach (TEntity entry in DBcontect)
            {
                if (Equals(entry.Id, id))
                {
                    return entry;
                }
            }
            return default(TEntity);
        }

        public void Delete(TEntity entry)
        {
            DBcontect.Remove(entry);
        }
        //public TEntity Update(Tid id, TEntity newEntery)
        //{
        //    TEntity entry = GetById(id);
        //    newEntery.RegistrationTime = entry.RegistrationTime;
        //    newEntery.Id = entry.Id;
        //    entry = newEntery;
        //    return entry;
        //}

    }
}
