using DataValidator.Configuration.Expression;
using DataValidator.ValidateExpression;
using System;
using System.Collections.Generic;

namespace DataValidator
{
    public class DataValidator : IDataValidator
    {
        private Dictionary<Type, IValidator> _validateExpressions;

        public DataValidator(ConfigurationExpression config)
        {
            _validateExpressions = new Dictionary<Type, IValidator>();

            config.Profiles.ForEach(profile => {
                foreach (var validateExpression in profile.ValidateExpressions)
                    _validateExpressions.Add(validateExpression.Key, validateExpression.Value as IValidator);
            });
        }

        public DataValidationException Validate<Data>(Data data)
        {
            Type type = typeof(Data);
            return _validateExpressions[type].Validate(data);
        }
    }
}
