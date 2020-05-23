using Application.Account.Interface;
using AutoMapper;
using RepositoryManager;
using Persistance.RepositoryProfiles.Account;
using Application.Account.DataModel.Seeked.Data;
using DataValidator;
using Application.Account.DataModel.Sended;

namespace Application.Account
{
    public class AccountQuery : App, IAccountQuery
    {
        #region Properties and Constructor

        public AccountQuery (
            IRepositoryManager repositoryManager,
            IDataValidator dataValidator,
            IMapper mapper
        ) : base(repositoryManager, dataValidator, mapper)
        {}

        #endregion

        #region IAccountQuery implementation

        public object GetAccountIdByLogin(LoginModel model)
        {
            ValidateData(model);

            return _repositoryManager
                .Repository<Persistance.Entities.Account>()
                .Select<AccountIdInfoSelector>(o => o.Email == model.Email)[0];
        }

        #endregion
    }
}
