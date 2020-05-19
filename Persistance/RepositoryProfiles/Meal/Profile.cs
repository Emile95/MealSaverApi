using Persistance.Database;
using RepositoryManager.Configuration;
namespace Persistance.RepositoryProfiles.Meal
{
    public class MealRepositoryProfile : RepositoryProfile
    {
        private readonly IDatabase _database;

        public MealRepositoryProfile(
            IDatabase database
        )
        {
            _database = database;

            CreateRepository<Entities.Meal>()
                .ForDelete(predicate => _database.Delete(predicate))
                .ForInsert(item => _database.Insert(item))
                .ForUpdate((predicate,item) => _database.Update(predicate,item))
                .ForSelect((predicate,length,index) => 
                    _database.Select(predicate, o => new MealInfoSelector { Id = o.Id, AccountId = o.AccountId, Date = o.Date }, length,index))
                .ForSelect((predicate, length, index) =>
                    _database.Select(predicate, o => new EmptySelector {  }, length, index));
        }

        
    }
}
