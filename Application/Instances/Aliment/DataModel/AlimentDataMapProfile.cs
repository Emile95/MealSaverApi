using Application.Aliment.DataModel.Seeked.Data;
using Application.Aliment.DataModel.Sended;
using Application.Interface.SeekedDataMapping;
using AutoMapper;
using System;

namespace Application.Aliment
{
    public class AlimentDataMapProfile : Profile
    {
        #region Constructor And Properties

        private readonly ISeekedDataMapping<AlimentView> _alimentViewMapping;

        public AlimentDataMapProfile(
            ISeekedDataMapping<AlimentView> alimentViewMapping
        )
        {
            CreateMap<AlimentModel, Persistance.Entities.Aliment>();
            CreateMap<Persistance.Entities.Aliment, AlimentModel>();

            _alimentViewMapping = alimentViewMapping;
            _alimentViewMapping.CreateMap(this);
        }

        #endregion
    }
}
