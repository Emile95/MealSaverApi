using DataValidator.Configuration;

namespace Application.Interface.SendedDataValidation
{
    public interface ISendedDataValidation<Data>
    {
        void CreateValidations(Profile profile);
    }
}
