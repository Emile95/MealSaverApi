using Application.Node.Interface;
using Application.Node.DataModel.Sended;
using DataValidator;
using AutoMapper;
using RepositoryManager;
using Persistance.RepositoryProfiles.Account;

namespace Application.Node
{
    public class NodeCommand : App, INodeCommand 
    {
        #region Properties and Constructor

        public NodeCommand(
            IRepositoryManager repositoryManager,
            IDataValidator dataValidator,
            IMapper mapper
        ) : base(repositoryManager, dataValidator, mapper)
        { }

        #endregion

        #region INodeCommand implementation

        public object Login(LoginModel model)
        {
            ValidateData(model);
            
            return _repositoryManager
                .Repository<Persistance.Entities.Account>()
                .Select<AccountLimitedInfoSelector>(o => o.Email == model.Account);
        }

        #endregion
    }
}
