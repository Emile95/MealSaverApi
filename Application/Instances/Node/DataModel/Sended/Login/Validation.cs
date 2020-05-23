using Application.Interface.SendedDataValidation;
using DataValidator.Configuration;
using Persistance.RepositoryProfiles.Account;
using RepositoryManager;
using System;
using System.Collections.Generic;

namespace Application.Node.DataModel.Sended
{
    public class LoginModelValidation : ISendedDataValidation<LoginModel>
    {
        #region Constructor and Properties

        private readonly IRepositoryManager _repositoryManager;

        public LoginModelValidation(
            IRepositoryManager repositoryManager
        )
        {
            _repositoryManager = repositoryManager;
        }

        #endregion

        #region Private Methods

        public bool ValidateLogin(Tuple<string,string> login)
        {
            List<AccountPasswordInfoSelector> selectors = _repositoryManager
                .Repository<Persistance.Entities.Account>()
                .Select<AccountPasswordInfoSelector>(o => o.Email == login.Item1);

            if(selectors.Count != 0)
            {
                AccountPasswordInfoSelector selector = selectors[0];
                if (selector.Password != login.Item2)
                    return false;
            }

            return true;
        }

        #endregion

        #region ISendedDataValidation Implementation

        public void CreateValidations(Profile profile)
        {
            profile.CreateValidator<LoginModel>()
                .ForValue(
                    data => new Tuple<string,string>(data.Account, data.Password),
                    value => value
                        .ForNoValidate(o => o == null)
                        .ForValidate(
                            o => ValidateLogin(o),
                            "Invalid"
                        )
                );
        }
    
        #endregion
    }
}
