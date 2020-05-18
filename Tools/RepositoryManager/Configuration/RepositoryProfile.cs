using RepositoryManager.CrudConfiguration;

namespace RepositoryManager.Configuration
{
    public class RepositoryProfile
    {
        internal object _repository;

        public ICrudConfiguration<Entity> CreateRepository<Entity>() where Entity :class, new()
        {
            ICrudConfiguration<Entity> repository = new CrudConfiguration<Entity>();
            _repository = repository;
            return repository;
        }
    }
}
