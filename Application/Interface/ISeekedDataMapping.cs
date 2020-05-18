using AutoMapper;

namespace Application.Interface.SeekedDataMapping
{
    public interface ISeekedDataMapping<Data>
    {
        void CreateMap(Profile profile);
    }
}
