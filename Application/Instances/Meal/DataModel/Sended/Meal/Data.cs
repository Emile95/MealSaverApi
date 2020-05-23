using System.Collections.Generic;

namespace Application.Meal.DataModel.Sended
{
    public class MealModel
    {
        public int? Id { get; set; }
        public int? AccountId { get; set; }
        public List<Aliment> Aliments { get; set; }
        public string Datetime { get; set; }

        public class Aliment
        {
            public int? Id { get; set; }
            public int Quantity { get; set; }
        }
    }
}
