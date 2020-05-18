using DataValidator.ValidateExpression.ValueConfigurationExpression;
using System;
using System.Linq.Expressions;

namespace DataValidator.ValidateExpression
{
    public interface IValidateExpression<Data> where Data : class
    {
        IValidateExpression<Data> ForValue<Value>(string valueName, Expression<Func<Data,Value>> expression, Action<IValueConfigurationExpression<Data, Value>> valueOption);
    }
}
