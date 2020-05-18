using Application.Account.DataModel.Sended;
using Application.Interface.SendedDataValidation;
using DataValidator.Configuration;

namespace Application.Account
{
    public class AccountValidationProfile : Profile
    {
        private readonly ISendedDataValidation<AccountModel> _accountModelValidation;

        public AccountValidationProfile(
            ISendedDataValidation<AccountModel> accountModelValidation
        )
        {
            _accountModelValidation = accountModelValidation;
            _accountModelValidation.CreateValidations(this);
        }
    }
}
