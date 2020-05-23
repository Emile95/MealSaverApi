using System;

namespace Persistance.Entities
{
    public partial class MealXAliment
    {
        public MealXAliment() { }

        public MealXAliment(MealXAliment entity)
        {
            Id = entity.Id;
            MealId = entity.MealId;
            AlimentId = entity.AlimentId;
            Quantity = entity.Quantity;
        }

        public int Id { get; set; }
        public int MealId { get; set; }
        public int AlimentId { get; set; }
        public int Quantity { get; set; }
    }
}
