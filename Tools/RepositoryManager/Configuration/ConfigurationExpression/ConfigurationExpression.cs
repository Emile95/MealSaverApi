using System.Collections.Generic;

namespace RepositoryManager.Configuration
{
    public class ConfigurationExpression : IConfigurationExpression
    {
        internal List<RepositoryProfile> Profiles { get; set; }

        public ConfigurationExpression()
        {
            Profiles = new List<RepositoryProfile>();
        }

        public IConfigurationExpression AddProfile(RepositoryProfile profile)
        {
            Profiles.Add(profile);
            return this;
        }
    }
}
