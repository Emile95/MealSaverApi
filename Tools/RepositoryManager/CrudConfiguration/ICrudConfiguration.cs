using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace RepositoryManager.CrudConfiguration
{
    public interface ICrudConfiguration<Entity> where Entity : class, new()
    {
        ICrudConfiguration<Entity> ForSelect<Selector>(Expression<Func<Expression<Func<Entity, bool>>, int, int, List<Selector>>> select);
        ICrudConfiguration<Entity> ForDelete(Expression<Action<Func<Entity,bool>>> delete);
        ICrudConfiguration<Entity> ForUpdate(Expression<Action<Expression<Func<Entity, bool>>,Entity>> update);
        ICrudConfiguration<Entity> ForInsert(Expression<Func<Entity,Entity>> insert);
    }
}
