namespace RepositoryManager.CrudConfiguration.Crud.ResultCrud
{
    public class InsertResult<Entity> : Result
    {
        public Entity InsertedEntity { get; set; }
    }
}
