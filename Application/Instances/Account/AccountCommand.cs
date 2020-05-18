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
            ValidateData(account);

            return _repositoryManager
                .Repository<Persistance.Entities.Account>()
                .Insert(_mapper.Map<Persistance.Entities.Account>(account));
        }

        public object Update(AccountModel account)
        {
            ValidateData(account);

            _repositoryManager
                .Repository<Persistance.Entities.Account>()
                .Update(
                    o => o.Id == account.Id,
                   _mapper.Map<Persistance.Entities.Account>(account)
                );

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
