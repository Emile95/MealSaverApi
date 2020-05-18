using System.Collections.Generic;

namespace DataValidator.Configuration.Expression
{
    public class ConfigurationExpression : IConfigurationExpression
    {
        public List<Profile> Profiles { get; set; }

        public ConfigurationExpression()
        {
            Profiles = new List<Profile>();
        }

        public IConfigurationExpression AddProfile(Profile profile)
        {
            Profiles.Add(profile);
            return this;
        }
    }
}
