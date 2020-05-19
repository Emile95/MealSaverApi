using Application.Interface.SendedDataValidation;
using DataValidator.Configuration;
using Persistance.RepositoryProfiles;
using RepositoryManager;
using System;
using System.Globalization;
using System.Linq;

namespace Application.Aliment.DataModel.Sended
{
    public class AlimentModelValidation : ISendedDataValidation<AlimentModel>
    {
        #region Constructor and Properties

        private readonly IRepositoryManager _repositoryManager;

        public AlimentModelValidation(
            IRepositoryManager repositoryManager
        )
        {
            _repositoryManager = repositoryManager;
        }

        #endregion

        #region Private Methods

        #endregion

        #region ISendedDataValidation Implementation

        public void CreateValidations(Profile profile)
        {
            profile.CreateValidator<AlimentModel>()
                .ForValue(
                    "Name",
                    data => data.Name,
                    value => value
                        .ForNoValidate(o => o == null)
                        .ForValidate(
                            o => o.Length <= 20,
                            "MaxCharacters:20"
                        )
                );
        }
    
        #endregion
    }
}
