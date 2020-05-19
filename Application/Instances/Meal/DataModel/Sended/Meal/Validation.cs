using Application.Interface.SendedDataValidation;
using DataValidator.Configuration;
using Persistance.RepositoryProfiles;
using RepositoryManager;
using System;
using System.Globalization;
using System.Linq;

namespace Application.Meal.DataModel.Sended
{
    public class MealModelValidation : ISendedDataValidation<MealModel>
    {
        #region Constructor and Properties

        private readonly IRepositoryManager _repositoryManager;

        public MealModelValidation(
            IRepositoryManager repositoryManager
        )
        {
            _repositoryManager = repositoryManager;
        }

        #endregion

        #region Private Methods

        public bool ValidateDate(string dateStr)
        {
            DateTime date;
            return DateTime.TryParse(dateStr, out date);
        }

        #endregion

        #region ISendedDataValidation Implementation

        public void CreateValidations(Profile profile)
        {
            profile.CreateValidator<MealModel>()
                .ForValue(
                    "Description",
                    data => data.Description,
                    value => value
                        .ForNoValidate(o => o == null)
                        .ForValidate(
                            o => o.Length > 1,
                            "MinCharacters:1"
                        )
                        .ForValidate(
                            o => o.Length <= 100,
                            "MaxCharacters:100"
                        )
                )
                .ForValue(
                    "Datetime",
                    data => data.Datetime,
                    value => value
                        .ForNoValidate(o => o == null)
                        .ForValidate(
                            o => ValidateDate(o),
                            "IsNotValidDate"
                        )
                );
        }
    
        #endregion
    }
}
