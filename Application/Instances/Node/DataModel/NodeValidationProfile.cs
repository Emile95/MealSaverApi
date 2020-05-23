using Application.Node.DataModel.Sended;
using Application.Interface.SendedDataValidation;
using DataValidator.Configuration;

namespace Application.Node
{
    public class NodeValidationProfile : Profile
    {
        private readonly ISendedDataValidation<LoginModel> _nodeModelValidation;

        public NodeValidationProfile(
            ISendedDataValidation<LoginModel> nodeModelValidation
        )
        {
            _nodeModelValidation = nodeModelValidation;
            _nodeModelValidation.CreateValidations(this);
        }
    }
}
