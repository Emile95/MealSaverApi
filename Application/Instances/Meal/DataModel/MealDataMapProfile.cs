using Application.Meal.DataModel.Seeked.Data;
using Application.Meal.DataModel.Sended;
using Application.Interface.SeekedDataMapping;
using AutoMapper;
using System;

namespace Application.Meal
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
                .ForMember(o => o.Datetime, opt => opt.MapFrom(o => DateTime.Parse(o.Datetime)));
            CreateMap<Persistance.Entities.Meal, MealModel>();

            _mealViewMapping = mealViewMapping;
            _mealViewMapping.CreateMap(this);
        }

        #endregion
    }
}
