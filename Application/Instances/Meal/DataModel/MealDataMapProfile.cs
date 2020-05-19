using Application.Meal.DataModel.Seeked.Data;
using Application.Meal.DataModel.Sended;
using Application.Interface.SeekedDataMapping;
using AutoMapper;
using System;

namespace Application.Account
{
    public class MealDataMapProfile : Profile
    {
        #region Constructor And Properties

        private readonly ISeekedDataMapping<MealView> _mealViewMapping;

        public MealDataMapProfile(
            ISeekedDataMapping<MealView> mealViewMapping
        )
        {
            CreateMap<MealModel, Persistance.Entities.Meal>()
                .ForMember(o => o.Date, opt => opt.MapFrom(o => DateTime.Parse(o.Date)));
            CreateMap<Persistance.Entities.Meal, MealModel>();

            _mealViewMapping = mealViewMapping;
            _mealViewMapping.CreateMap(this);
        }

        #endregion
    }
}
