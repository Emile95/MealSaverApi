using Application.Account.Interface;
using Application.Account.DataModel.Sended;
using DataValidator;
using AutoMapper;
using RepositoryManager;

namespace Application.Account
{
    public class AccountCommand : Command, IAccountCommand 
    {
        #region Properties and Constructor

        public AccountCommand(
            IRepositoryManager repositoryManager,
            IDataValidator dataValidator,
            IMapper mapper
        ) : base(repositoryManager, dataValidator, mapper)
        { }

        #endregion

        #region IUserCommand implementation

        public object Add(AccountModel account)
        {
            return Insert<Persistance.Entities.Account, AccountModel>(account);
        }

        public object Update(AccountModel account)
        {
            Update<Persistance.Entities.Account, AccountModel>(account, o => o.Id == account.Id);
            return null; 
        }

        public object RemoveById(int id)
        {
            _repositoryManager
                .Repository<Persistance.Entities.Account>()
                .Delete(o => o.Id == id);
            return null;
        }

        #endregion
    }
}
