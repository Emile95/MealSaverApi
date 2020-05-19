using Application.Interface.SendedDataValidation;
using DataValidator.Configuration;
using Persistance.RepositoryProfiles;
using Persistance.RepositoryProfiles.Aliment;
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

        public bool CheckIfNonExistant(int accountId, string Name)
        {
            return _repositoryManager
                .Repository<Persistance.Entities.Aliment>()
                .Select<AlimentInfoSelector>(o => o.AccountId == accountId)
                .Where(o => string.Equals(o.Name, Name, StringComparison.OrdinalIgnoreCase))
                .Count() == 0;
        }

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
                            "MaxCharacters=20"
                        )
                )
                .ForValue(
                    data => new Tuple<string,int>(data.Name, data.AccountId.Value),
                    value => value
                        .ForValidate(
                            o => CheckIfNonExistant(o.Item2, o.Item1),
                            "ExistAlready"
                        )
                );
        }
    
        #endregion
    }
}
