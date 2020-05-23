using Persistance.Database;
using RepositoryManager.Configuration;
namespace Persistance.RepositoryProfiles.MealXAliment
{
    public class MealXAlimentRepositoryProfile : RepositoryProfile
    {
        private readonly IDatabase _database;

        public MealXAlimentRepositoryProfile(
            IDatabase database
        )
        {
            _database = database;

            CreateRepository<Entities.MealXAliment>()
                .ForDelete(predicate => _database.Delete(predicate))
                .ForInsert(item => _database.Insert(item))
                .ForUpdate((predicate,item) => _database.Update(predicate,item))
                .ForSelect((predicate,length,index) => 
                    _database.Select(predicate, o => new MealXAlimentInfoSelector { Id = o.Id, AlimentId = o.AlimentId, MealId = o.MealId, Quantity = o.Quantity }, length,index))
                .ForSelect((predicate, length, index) =>
                    _database.Select(predicate, o => new EmptySelector {  }, length, index));
        }
    }
}
