using Application.Account.DataModel.Seeked.Data;
using AutoMapper;
using RepositoryManager;
using Persistance.RepositoryProfiles.Account;
using Application.Interface.SeekedDataMapping;
using Persistance.RepositoryProfiles;

namespace Application.Account.DataModel.Seeked.Mapping
{
    public class AccountViewMapping : ISeekedDataMapping<AccountView>
    {
        #region Constructor and Properties

        private readonly IRepositoryManager _repositoryManager;

        public AccountViewMapping(
            IRepositoryManager repositoryManager
        )
        {
            _repositoryManager = repositoryManager;
        }

        #endregion

        #region Private Methods

        private int GetNbMeal(int id)
        {
            return 0;
            /*return _repositoryManager
                .Repository<Persistance.Entities.Publication>()
                .Select<EmptySelector>(o => o.AccountId == id)
                .Count;*/
        }

        #endregion

        #region ISeekedDataMapping

        public void CreateMap(Profile profile)
        {
            profile.CreateMap<AccountLimitedInfoSelector, AccountView>()
                .ForMember(
                    o => o.NbMeal,
                    o => o.MapFrom(s => GetNbMeal(s.Id))
                );
        }

        #endregion
    }
}
