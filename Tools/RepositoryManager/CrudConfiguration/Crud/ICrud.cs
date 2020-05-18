using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace RepositoryManager.CrudConfiguration.Crud
{
    public interface ICrud<Entity>
    {
        List<Selector> Select<Selector>(Expression<Func<Entity, bool>> predicate, int length = 0, int index = 0)
            where Selector : class, new();

        void Delete(Func<Entity, bool> predicate);

        Entity Insert(Entity entity);

        void Update(Expression<Func<Entity, bool>> predicate, Entity entity);
    }
}
