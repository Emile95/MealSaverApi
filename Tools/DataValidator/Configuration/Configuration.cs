using DataValidator.Configuration.Expression;
using System;

namespace DataValidator.Configuration
{
    public class Configuration
    {
        private readonly ConfigurationExpression _expression;

        public Configuration(Action<IConfigurationExpression> expression)
        {
            _expression = new ConfigurationExpression();
            expression(_expression);
        }

        public IDataValidator CreateValidator()
        {
            return new DataValidator(_expression);
        }
    }
}
