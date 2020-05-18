using AutoMapper;
using RepositoryManager;

namespace Application
{
    public class App
    {
        #region Properties and Constructor

        protected readonly IRepositoryManager _repositoryManager;
        protected readonly IMapper _mapper;

        public App(
            IRepositoryManager repositoryManager,
            IMapper mapper
        )
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        #endregion
    }
}
