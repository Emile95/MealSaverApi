using DataValidator.ValidateExpression.ValueConfigurationExpression;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DataValidator.ValidateExpression
{
    public class ValidateExpression<Data> : IValidateExpression<Data>, IValidator where Data : class
    {
        public List<IValidator> ValueConfigs { get; set; }

        public ValidateExpression()
        {
            ValueConfigs = new List<IValidator>();
        }

        public IValidateExpression<Data> ForValue<Value>(string valueName, Expression<Func<Data, Value>> expression, Action<IValueConfigurationExpression<Data, Value>> valueOption)
        {
            ValueConfigureExpression<Data, Value> valueConfig = new ValueConfigureExpression<Data, Value>(expression, valueName);
            valueOption(valueConfig);
            ValueConfigs.Add(valueConfig);
            return this;
        }

        public DataValidationException Validate(object data)
        {
            DataValidationException exception = null;
            foreach (IValidator ValueConfig in ValueConfigs)
            {
                exception = ValueConfig.Validate(data as Data);
                if (exception != null) return exception;
            }
            return exception;
        }
    }
}
