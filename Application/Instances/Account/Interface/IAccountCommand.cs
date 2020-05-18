using Application.Account.DataModel.Sended;

namespace Application.Account.Interface
{
    public interface IAccountCommand
    {
        object Add(AccountModel account);
        object RemoveById(int id);
        object Update(AccountModel account);
    }
}
