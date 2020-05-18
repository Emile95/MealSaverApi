using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Persistance.Database.Context;
using System.Reflection;

namespace Persistance.Database
{
    public class Database : IDatabase
    {
        #region Properties and Constructor

        private readonly VimoContext _database;

        public Database(
             VimoContext database
        )
        {
            _database = database;
        }

        #endregion

        #region Private Methods

        private void UpdateEntity<Entity>(Entity entity, Entity item)
        {
            foreach(PropertyInfo prop in entity.GetType().GetProperties())
            {
                object valueEntity = prop.GetValue(entity);
                object valueItem = prop.GetValue(item);
                if(!valueEntity.Equals(valueItem) && valueItem != null)
                    prop.SetValue(entity, valueItem);
            }
        }

        #endregion

        #region IRepository implementation

        public List<Selector> Select<Entity,Selector>(Expression<Func<Entity, bool>> predicate, Expression<Func<Entity, Selector>> select = null, int length = 0, int index = 0) 
            where Entity : class, new()
            where Selector : class, new()
        {
            if (select == null) select = o => (Selector)Activator.CreateInstance(typeof(Selector), new[] { o });

            IQueryable<Entity> query = _database.Set<Entity>().AsNoTracking();

            if (predicate != null) query = query.Where(predicate);

            if (index != 0) query = query.Skip(index);
            if (length != 0) query = query.Take(length);

            return query.Select(select).ToList();
        }

        public List<Entity> Delete<Entity>(Func<Entity, bool> predicate) where Entity : class, new()
        {
            DbSet<Entity> set = _database.Set<Entity>();
            Entity[] toRemoves = set.Where(predicate).ToArray();

            List<Entity> removedEntities = new List<Entity>(toRemoves);

            foreach (Entity toRemove in toRemoves)
                _database.Remove(toRemove);

            _database.SaveChanges();

            return removedEntities;
        }

        public Entity Insert<Entity>(Entity item) where Entity : class
        {
            try {
                _database.Add(item);
                _database.SaveChanges();
            }
            catch (Exception e)
            {
                _database.Set<Entity>().Remove(item);
                throw new Exception(e.InnerException.Message);
            }
            return item;
        }

        public void Update<Entity>(Expression<Func<Entity, bool>> predicate, Entity item) where Entity : class
        {
            try {
                IQueryable<Entity> entities = _database.Set<Entity>().Where(predicate);
                foreach (Entity entity in entities)
                    UpdateEntity(entity,item);
                _database.UpdateRange(entities);
                _database.SaveChanges();
            }
            catch (Exception e) {
                throw new Exception(e.InnerException.Message);
            }
        }

        #endregion
    }
}
