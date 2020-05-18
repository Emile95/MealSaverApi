namespace DataValidator.ValidateExpression
{
    public interface IValidator
    {
        DataValidationException Validate(object data);
    }
}
