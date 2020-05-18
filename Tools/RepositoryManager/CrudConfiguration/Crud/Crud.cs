using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace RepositoryManager.CrudConfiguration.Crud
{
    public class Crud<Entity> : ICrud<Entity> where Entity: class, new()
    {
        private readonly Dictionary<Type, object> _selectExpression;
        private readonly Expression<Func<Entity, Entity>> _insertExpression;
        private readonly Expression<Action<Func<Entity, bool>>> _deleteExpression;
        private readonly Expression<Action<Expression<Func<Entity, bool>>,Entity>> _updateExpression;

        public Crud(
            Dictionary<Type, object> selectExpression,
            Expression<Func<Entity, Entity>> insertExpression,
            Expression<Action<Func<Entity, bool>>> deleteExpression,
            Expression<Action<Expression<Func<Entity, bool>>,Entity>> updateExpression
        )
        {
            _selectExpression = selectExpression;
            _insertExpression = insertExpression;
            _deleteExpression = deleteExpression;
            _updateExpression = updateExpression;
        }

        public List<Selector> Select<Selector>(Expression<Func<Entity, bool>> predicate, int length = 0, int index = 0)
            where Selector : class, new()
        {
            Expression<Func<Expression<Func<Entity, bool>>, int, int, List<Selector>>> select = _selectExpression[typeof(Selector)]
            as Expression<Func<Expression<Func<Entity, bool>>, int, int, List<Selector>>>;
            return select.Compile().Invoke(predicate, length, index);
        }

        public void Delete(Func<Entity, bool> predicate)
        {
            _deleteExpression.Compile().Invoke(predicate);
        }

        public Entity Insert(Entity entity)
        {
            return _insertExpression.Compile().Invoke(entity);
        }

        public void Update(Expression<Func<Entity, bool>> predicate, Entity entity)
        {
            _updateExpression.Compile().Invoke(predicate,entity);
        }
    }
}
