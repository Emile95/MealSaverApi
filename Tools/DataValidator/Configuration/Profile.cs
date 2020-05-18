using DataValidator.ValidateExpression;
using System;
using System.Collections.Generic;

namespace DataValidator.Configuration
{
    public class Profile
    {
        internal Dictionary<Type, IValidator> ValidateExpressions { get; set; } = new Dictionary<Type, IValidator>();

        public IValidateExpression<Data> CreateValidator<Data>() where Data : class
        {
            ValidateExpression<Data> expression = new ValidateExpression<Data>();
            ValidateExpressions.Add(typeof(Data), expression);
            return expression;
        }
    }
}
