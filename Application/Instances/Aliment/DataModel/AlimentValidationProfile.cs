using Application.Aliment.DataModel.Sended;
using Application.Interface.SendedDataValidation;
using DataValidator.Configuration;

namespace Application.Aliment
{
    public class AlimentValidationProfile : Profile
    {
        private readonly ISendedDataValidation<AlimentModel> _alimentModelValidation;

        public AlimentValidationProfile(
            ISendedDataValidation<AlimentModel> alimentModelValidation
        )
        {
            _alimentModelValidation = alimentModelValidation;
            _alimentModelValidation.CreateValidations(this);
        }
    }
}
