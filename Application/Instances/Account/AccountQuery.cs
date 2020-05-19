using Application.Account.Interface;
using AutoMapper;
using RepositoryManager;
using Persistance.RepositoryProfiles.Account;
using Application.Account.DataModel.Seeked.Data;
using DataValidator;

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

        #endregion
    }
}
