using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Persistance.Database
{
    public interface IDatabase
    {
        List<Selector> Select<Entity, Selector>(Expression<Func<Entity, bool>> predicate, Expression<Func<Entity, Selector>> select = null, int length = 0, int index = 0)
            where Entity : class, new()
            where Selector : class, new();

        List<Entity> Delete<Entity>(Func<Entity, bool> predicate) where Entity : class, new();

        Entity Insert<Entity>(Entity item) where Entity : class;

        void Update<Entity>(Expression<Func<Entity, bool>> predicate, Entity item) where Entity : class;
    }
}
