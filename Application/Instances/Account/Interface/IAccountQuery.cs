using Application.Account.DataModel.Sended;
using System.Collections.Generic;

namespace Application.Account.Interface
{
    public interface IAccountQuery
    {
        object GetAccountIdByLogin(LoginModel model);
    }
}
