using Application.Aliment.DataModel.Seeked.Data;
using AutoMapper;
using RepositoryManager;
using Application.Interface.SeekedDataMapping;
using Persistance.RepositoryProfiles;
using Persistance.RepositoryProfiles.Aliment;

namespace Application.Aliment.DataModel.Seeked.Mapping
{
    public class AlimentViewMapping : ISeekedDataMapping<AlimentView>
    {
        #region Constructor and Properties

        private readonly IRepositoryManager _repositoryManager;

        public AlimentViewMapping(
            IRepositoryManager repositoryManager
        )
        {
            _repositoryManager = repositoryManager;
        }

        #endregion

        #region Private Methods

        #endregion

        #region ISeekedDataMapping

        public void CreateMap(Profile profile)
        {
            profile.CreateMap<AlimentInfoSelector, AlimentView>();
        }

        #endregion
    }
}
