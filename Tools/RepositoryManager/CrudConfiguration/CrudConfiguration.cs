using RepositoryManager.CrudConfiguration.Crud;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace RepositoryManager.CrudConfiguration
{
    public class CrudConfiguration<Entity> : ICrudConfiguration<Entity> where Entity : class, new()
    {
        private readonly Dictionary<Type, object> _selectExpression;
        private Expression<Func<Entity,Entity>> _insertExpression;
        private Expression<Action<Func<Entity, bool>>> _deleteExpression;
        private Expression<Action<Expression<Func<Entity, bool>>,Entity>> _updateExpression;

        public CrudConfiguration()
        {
            _selectExpression = new Dictionary<Type, object>();
        }

        public ICrudConfiguration<Entity> ForSelect<Selector>(Expression<Func<Expression<Func<Entity, bool>>, int, int, List<Selector>>> select)
        {
            _selectExpression.Add(typeof(Selector), select);
            return this;
        }

        public ICrudConfiguration<Entity> ForDelete(Expression<Action<Func<Entity, bool>>> delete)
        {
            _deleteExpression = delete;
            return this;
        }

        public ICrudConfiguration<Entity> ForUpdate(Expression<Action<Expression<Func<Entity, bool>>,Entity>> update)
        {
            _updateExpression = update;
            return this;
        }

        public ICrudConfiguration<Entity> ForInsert(Expression<Func<Entity, Entity>> insert)
        {
            _insertExpression = insert;
            return this;
        }

        public ICrud<Entity> CreateCrud()
        {
            return new Crud<Entity>(
                _selectExpression,
                _insertExpression,
                _deleteExpression,
                _updateExpression
            );
        }
    }
}
