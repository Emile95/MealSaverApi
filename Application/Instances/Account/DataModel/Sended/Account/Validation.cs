using Application.Interface.SendedDataValidation;
using DataValidator.Configuration;
using Persistance.RepositoryProfiles;
using RepositoryManager;
using System;
using System.Linq;

namespace Application.Account.DataModel.Sended
{
    public class AccountModelValidation : ISendedDataValidation<AccountModel>
    {
        #region Constructor and Properties

        private readonly IRepositoryManager _repositoryManager;

        public AccountModelValidation(
            IRepositoryManager repositoryManager
        )
        {
            _repositoryManager = repositoryManager;
        }

        #endregion

        #region Private Methods

        private bool IsValidEmail(string email)
        {
            try {
                var addr = new System.Net.Mail.MailAddress(email);
                return true;
            }
            catch (Exception e) { return false; }
        }

        private bool IsUniqueEmail(string email)
        {
            int nbOccurence = _repositoryManager
                .Repository<Persistance.Entities.Account>()
                .Select<EmptySelector>(o => o.Email == email, 0, 0)
                .Count;
            return nbOccurence == 0;
        }

        #endregion

        #region ISendedDataValidation Implementation

        public void CreateValidations(Profile profile)
        {
            profile.CreateValidator<AccountModel>()
                .ForValue(
                    "FirstName",
                    data => data.FirstName,
                    value => value
                        .ForNoValidate(o => o == null)
                        .ForValidate(
                            o => Char.IsUpper(o[0]),
                            "FirstCharUpper"
                        )
                        .ForValidate(
                            o => o.Length <= 300,
                            "MaxCharacters=300"
                        )
                        .ForValidate(
                            o => o.Length >= 1,
                            "MinCharacters=1"
                        )
                )
                .ForValue(
                    "LastName",
                    data => data.LastName,
                    value => value
                        .ForNoValidate(o => o == null)
                        .ForValidate(
                            o => Char.IsUpper(o[0]),
                            "FirstCharUpper"
                        )
                        .ForValidate(
                            o => o.Length <= 300,
                            "MaxCharacters=300"
                        )
                        .ForValidate(
                            o => o.Length >= 1,
                            "MinCharacters=1"
                        )
                )
                .ForValue(
                    "Email",
                    data => data.Email,
                    value => value
                        .ForNoValidate(o => o == null)
                        .ForValidate(
                            o => IsValidEmail(o),
                            "NotValidEmail"
                        )
                        .ForValidate(
                            o => IsUniqueEmail(o),
                            "AlreadyUsed"
                        )
                )
                .ForValue(
                    "Password",
                    data => data.Password,
                    value => value
                        .ForNoValidate(o => o == null)
                        .ForValidate(
                            o => o.Length >= 8,
                            "MinCharacters=8"
                        )
                        .ForValidate(
                            o => o.Length <= 20,
                            "MaxCharacters=20"
                        )
                        .ForValidate(
                            o => o.Any(char.IsDigit) && o.Any(char.IsUpper) && o.Any(char.IsLower),
                            "NotDiversifiedString"
                        )
                );
        }
    
        #endregion
    }
}
