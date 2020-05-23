using Application.Node.Interface;
using AutoMapper;
using RepositoryManager;
using DataValidator;

namespace Application.Node
{
    public class NodeQuery : App, INodeQuery
    {
        #region Properties and Constructor

        public NodeQuery(
            IRepositoryManager repositoryManager,
            IDataValidator dataValidator,
            IMapper mapper
        ) : base(repositoryManager, dataValidator, mapper)
        {}

        #endregion

        #region INodeQuery implementation

        #endregion
    }
}
