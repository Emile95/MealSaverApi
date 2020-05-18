using Application.Account.DataModel.Seeked.Data;
using Application.Account.DataModel.Sended;
using Application.Interface.SeekedDataMapping;
using AutoMapper;

namespace Application.Account
{
    public class AccountDataMapProfile : Profile
    {
        #region Constructor And Properties

        private readonly ISeekedDataMapping<AccountView> _accountViewMapping;

        public AccountDataMapProfile(
            ISeekedDataMapping<AccountView> accountViewMapping
        )
        {
            CreateMap<AccountModel, Persistance.Entities.Account>();
            CreateMap<Persistance.Entities.Account, AccountModel>();

            _accountViewMapping = accountViewMapping;
            _accountViewMapping.CreateMap(this);
        }

        #endregion
    }
}
