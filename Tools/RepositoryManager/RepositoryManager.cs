using RepositoryManager.Configuration;
using RepositoryManager.CrudConfiguration.Crud;
using System;
using System.Collections.Generic;

namespace RepositoryManager
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly Dictionary<Type, object> _crudConfigs;

        public RepositoryManager(ConfigurationExpression _expression)
        {
            _crudConfigs = new Dictionary<Type, object>();
            foreach (RepositoryProfile profile in _expression.Profiles)
            {
                Type crudType = profile._repository.GetType().GetGenericArguments()[0];
                object obj = profile._repository.GetType()
                    .GetMethod("CreateCrud")
                    .Invoke(profile._repository, new object[] { });

                _crudConfigs.Add(crudType, obj);
            }
        }

        public ICrud<Entity> Repository<Entity>() where Entity : class, new()
        {
            return _crudConfigs[typeof(Entity)] as ICrud<Entity>;
        }
    }
}
