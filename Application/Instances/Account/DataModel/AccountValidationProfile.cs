using Application.Account.DataModel.Sended;
using Application.Interface.SendedDataValidation;
using DataValidator.Configuration;

namespace Application.Account
{
    public class AccountValidationProfile : Profile
    {
        private readonly ISendedDataValidation<AccountModel> _accountModelValidation;
        private readonly ISendedDataValidation<LoginModel> _loginModelValidation;

        public AccountValidationProfile(
            ISendedDataValidation<AccountModel> accountModelValidation,
            ISendedDataValidation<LoginModel> loginModelValidation
        )
        {
            _accountModelValidation = accountModelValidation;
            _accountModelValidation.CreateValidations(this);

            _loginModelValidation = loginModelValidation;
            _loginModelValidation.CreateValidations(this);
        }
    }
}
