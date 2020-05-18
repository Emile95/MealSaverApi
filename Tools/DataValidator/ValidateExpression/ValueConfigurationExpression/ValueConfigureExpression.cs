using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DataValidator.ValidateExpression.ValueConfigurationExpression
{
    public class ValueConfigureExpression<Data, Value> : IValueConfigurationExpression<Data, Value>, IValidator where Data : class
    {
        public readonly List<Tuple<Expression<Func<Value, bool>>, DataValidationException>> _validates;
        private readonly List<Expression<Func<Value, bool>>> _noValidates;
        private Tuple<Expression<Func<Value, bool>>, DataValidationException> _preValidate;
        private readonly Expression<Func<Data, Value>> _expression;
        private readonly string _name;

        public ValueConfigureExpression(Expression<Func<Data, Value>> expression, string name)
        {
            _validates = new List<Tuple<Expression<Func<Value, bool>>, DataValidationException>>();
            _noValidates = new List<Expression<Func<Value, bool>>>();

            _expression = expression;
            _name = name;
        }

        public IValueConfigurationExpression<Data, Value> ForValidate(Expression<Func<Value, bool>> expression, string exceptionMessage)
        {
            DataValidationException exception = new DataValidationException(typeof(Data).Name,_name, exceptionMessage);
            
            _validates.Add(
                new Tuple<Expression<Func<Value, bool>>, DataValidationException>(expression, exception)
            );
            return this;
        }

        public IValueConfigurationExpression<Data, Value> PreValidate(Expression<Func<Value, bool>> expression, string exceptionMessage)
        {
            DataValidationException exception = new DataValidationException(typeof(Data).Name, _name, exceptionMessage);
            _preValidate = new Tuple<Expression<Func<Value, bool>>, DataValidationException>(expression, exception);
            return this;
        }

        public IValueConfigurationExpression<Data, Value> ForNoValidate(Expression<Func<Value, bool>> expression)
        {
            _noValidates.Add(expression);
            return this;
        }

        public DataValidationException Validate(object data) 
        {
            Value value = _expression.Compile().Invoke(data as Data);

            if (_noValidates != null)
                foreach (Expression<Func<Value, bool>> noValidate in _noValidates)
                if (noValidate.Compile().Invoke(value))
                    return null;

            if(_preValidate != null)
                if (!_preValidate.Item1.Compile().Invoke(value))
                    return _preValidate.Item2;

            foreach (Tuple<Expression<Func<Value, bool>>, DataValidationException> validate in _validates)
                if(!validate.Item1.Compile().Invoke(value))
                    return validate.Item2;

            return null;
        }
    }
}
