using System;

namespace Persistance.RepositoryProfiles.MealXAliment
{
    public class MealXAlimentInfoSelector
    {
        public int Id { get; set; }
        public int MealId { get; set; }
        public int AlimentId { get; set; }
        public int Quantity { get; set; }
    }
}
