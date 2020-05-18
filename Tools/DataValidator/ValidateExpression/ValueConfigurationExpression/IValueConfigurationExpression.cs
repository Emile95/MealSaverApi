using System;
using System.Linq.Expressions;

namespace DataValidator.ValidateExpression.ValueConfigurationExpression
{
    public interface IValueConfigurationExpression<Data, Value> where Data : class
    {
        IValueConfigurationExpression<Data, Value> ForValidate(Expression<Func<Value,bool>> expression, string exceptionMessage);
        IValueConfigurationExpression<Data, Value> ForNoValidate(Expression<Func<Value, bool>> expression);
        IValueConfigurationExpression<Data, Value> PreValidate(Expression<Func<Value, bool>> expression, string exceptionMessage);
    }
}
