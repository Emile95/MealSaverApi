using Application.Interface.SendedDataValidation;
using DataValidator.Configuration;
using Persistance.RepositoryProfiles;
using Persistance.RepositoryProfiles.Aliment;
using RepositoryManager;
using System;
using System.Collections.Generic;

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

        public bool ValidateAlimentIds(List<MealModel.Aliment> aliments)
        {
            foreach(MealModel.Aliment aliment in aliments) {
                if (_repositoryManager
                    .Repository<Persistance.Entities.Aliment>()
                    .Select<AlimentInfoSelector>(o => o.Id == aliment.Id.Value)
                    .Count == 0)
                return false;
            }
            return true;
        }

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
                    "Datetime",
                    data => data.Datetime,
                    value => value
                        .ForNoValidate(o => o == null)
                        .ForValidate(
                            o => ValidateDate(o),
                            "IsNotValidDate"
                        )
                )
                .ForValue(
                    "AlimentIds",
                    data => data.Aliments,
                    value => value
                        .ForNoValidate(o => o == null)
                        .ForValidate(
                            o => ValidateAlimentIds(o),
                            "IsNotValidDate"
                        )
                );
        }
    
        #endregion
    }
}
