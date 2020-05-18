using RepositoryManager.CrudConfiguration.Crud;

namespace RepositoryManager
{
    public interface IRepositoryManager
    {
        ICrud<Entity> Repository<Entity>() where Entity : class, new();
    }
}
