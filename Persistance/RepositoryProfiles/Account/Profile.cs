using Persistance.Database;
using RepositoryManager.Configuration;
namespace Persistance.RepositoryProfiles.Account
{
    public class AccountRepositoryProfile : RepositoryProfile
    {
        private readonly IDatabase _database;

        public AccountRepositoryProfile(
            IDatabase database
        )
        {
            _database = database;

            CreateRepository<Entities.Account>()
                .ForDelete(predicate => _database.Delete(predicate))
                .ForInsert(item => _database.Insert(item))
                .ForUpdate((predicate,item) => _database.Update(predicate,item))
                .ForSelect((predicate,length,index) => 
                    _database.Select(predicate, o => new AccountLimitedInfoSelector { Id = o.Id, Email = o.Email, FirstName = o.FirstName, LastName = o.LastName }, length,index))
                .ForSelect((predicate, length, index) =>
                    _database.Select(predicate, o => new AccountPasswordInfoSelector { Password = o.Password }, length, index))
                .ForSelect((predicate, length, index) =>
                    _database.Select(predicate, o => new AccountIdInfoSelector { Id = o.Id }, length, index))
                .ForSelect((predicate, length, index) =>
                    _database.Select(predicate, o => new EmptySelector {  }, length, index));
        }

        
    }
}
