using System;

namespace RepositoryManager.Configuration
{
    public class Configuration
    {
        private readonly ConfigurationExpression _expression;

        public Configuration(Action<IConfigurationExpression> expression)
        {
            _expression = new ConfigurationExpression();
            expression(_expression);
        }

        public IRepositoryManager CreateRepositoryManager()
        {
            return new RepositoryManager(_expression);
        }
    }
}
