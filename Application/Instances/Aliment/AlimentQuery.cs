using Application.Aliment.Interface;
using AutoMapper;
using RepositoryManager;
using Persistance.RepositoryProfiles.Aliment;
using Application.Aliment.DataModel.Seeked.Data;
using DataValidator;

namespace Application.Aliment
{
    public class AlimentQuery : App, IAlimentQuery
    {
        #region Properties and Constructor

        public AlimentQuery(
            IRepositoryManager repositoryManager,
            IDataValidator dataValidator,
            IMapper mapper
        ) : base(repositoryManager, dataValidator, mapper)
        {}

        #endregion

        #region IAlimentQuery implementation

        #endregion
    }
}
