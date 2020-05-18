namespace RepositoryManager.Configuration
{
    public interface IConfigurationExpression
    {
        IConfigurationExpression AddProfile(RepositoryProfile profile);
    }
}
