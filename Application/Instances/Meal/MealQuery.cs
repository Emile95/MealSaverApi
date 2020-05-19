using Application.Meal.Interface;
using AutoMapper;
using RepositoryManager;
using Persistance.RepositoryProfiles.Meal;
using Application.Meal.DataModel.Seeked.Data;
using DataValidator;

namespace Application.Account
{
    public class MealQuery : App, IMealQuery
    {
        #region Properties and Constructor

        public MealQuery(
            IRepositoryManager repositoryManager,
            IDataValidator dataValidator,
            IMapper mapper
        ) : base(repositoryManager, dataValidator, mapper)
        {}

        #endregion

        #region IMealQuery implementation

        #endregion
    }
}
