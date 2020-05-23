using Application.Interface.SendedDataValidation;
using DataValidator.Configuration;
using Persistance.RepositoryProfiles;
using Persistance.RepositoryProfiles.Account;
using RepositoryManager;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Application.Account.DataModel.Sended
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

        private bool ValidateLogin(Tuple<string, string> login)
        {
            List<AccountPasswordInfoSelector> queryResult = _repositoryManager
                .Repository<Persistance.Entities.Account>()
                .Select<AccountPasswordInfoSelector>(o => o.Email == login.Item1);
            if (queryResult.Count == 0) return false;
            AccountPasswordInfoSelector selector = queryResult[0];
            if (selector.Password != login.Item2) return false;
            return true;
        }

        #endregion

        #region ISendedDataValidation Implementation

        public void CreateValidations(Profile profile)
        {
            profile.CreateValidator<LoginModel>()
                .ForValue(
                    data => new Tuple<string,string>(data.Email,data.Password),
                    value => value
                        .ForNoValidate(login => login == null)
                        .ForValidate(
                            login => ValidateLogin(login),
                            "InValid"
                        )
                );
        }
    
        #endregion
    }
}
