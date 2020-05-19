using Persistance.Database;
using RepositoryManager.Configuration;
namespace Persistance.RepositoryProfiles.Aliment
{
    public class AlimentRepositoryProfile : RepositoryProfile
    {
        private readonly IDatabase _database;

        public AlimentRepositoryProfile(
            IDatabase database
        )
        {
            _database = database;

            CreateRepository<Entities.Aliment>()
                .ForDelete(predicate => _database.Delete(predicate))
                .ForInsert(item => _database.Insert(item))
                .ForUpdate((predicate,item) => _database.Update(predicate,item))
                .ForSelect((predicate,length,index) => 
                    _database.Select(predicate, o => new AlimentInfoSelector { Id = o.Id, AccountId = o.AccountId, Name = o.Name }, length,index))
                .ForSelect((predicate, length, index) =>
                    _database.Select(predicate, o => new EmptySelector {  }, length, index));
        }

        
    }
}
