using Application.Account.Interface;
using AutoMapper;
using RepositoryManager;
using Persistance.RepositoryProfiles.Account;
using Application.Account.DataModel.Seeked.Data;

namespace Application.Account
{
    public class AccountQuery : Query, IAccountQuery
    {
        #region Properties and Constructor

        public AccountQuery (
            IRepositoryManager repositoryManager,
            IMapper mapper
        ) : base(repositoryManager, mapper)
        {}

        #endregion

        #region IUserQuery implementation


        #endregion
    }
}
