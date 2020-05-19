using Application.Meal.DataModel.Seeked.Data;
using AutoMapper;
using RepositoryManager;
using Persistance.RepositoryProfiles.Meal;
using Application.Interface.SeekedDataMapping;
using Persistance.RepositoryProfiles;

namespace Application.Meal.DataModel.Seeked.Mapping
{
    public class MealtViewMapping : ISeekedDataMapping<MealView>
    {
        #region Constructor and Properties

        private readonly IRepositoryManager _repositoryManager;

        public MealtViewMapping(
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
            profile.CreateMap<MealInfoSelector, MealView>();
        }

        #endregion
    }
}
