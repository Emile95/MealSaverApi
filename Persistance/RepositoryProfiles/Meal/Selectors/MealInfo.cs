using System;

namespace Persistance.RepositoryProfiles.Meal
{
    public class MealInfoSelector
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public string Description { get; set; }
        public DateTime Datetime { get; set; }
    }
}
