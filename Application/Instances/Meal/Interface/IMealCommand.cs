using Application.Meal.DataModel.Sended;

namespace Application.Meal.Interface
{
    public interface IMealCommand
    {
        object Add(MealModel model);
        object RemoveById(int id);
        object Update(MealModel model);
    }
}
