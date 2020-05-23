using System;
using System.Collections.Generic;

namespace Application.Meal.DataModel.Sended
{
    public class MealModel
    {
        public int? Id { get; set; }
        public int? AccountId { get; set; }
        public List<List<int>> Aliments { get; set; }
        public string Datetime { get; set; }
    }
}
