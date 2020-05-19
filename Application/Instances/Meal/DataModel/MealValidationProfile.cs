using Application.Meal.DataModel.Sended;
using Application.Interface.SendedDataValidation;
using DataValidator.Configuration;

namespace Application.Account
{
    public class MealValidationProfile : Profile
    {
        private readonly ISendedDataValidation<MealModel> __mealModelValidation;

        public MealValidationProfile(
            ISendedDataValidation<MealModel> mealModelValidation
        )
        {
            __mealModelValidation = mealModelValidation;
            __mealModelValidation.CreateValidations(this);
        }
    }
}
