using Application.Aliment.Interface;
using Application.Aliment.DataModel.Sended;
using DataValidator;
using AutoMapper;
using RepositoryManager;

namespace Application.Aliment
{
    public class AlimentCommand : App, IAlimentCommand 
    {
        #region Properties and Constructor

        public AlimentCommand(
            IRepositoryManager repositoryManager,
            IDataValidator dataValidator,
            IMapper mapper
        ) : base(repositoryManager, dataValidator, mapper)
        { }

        #endregion

        #region IAlimentCommand implementation

        public object Add(AlimentModel model)
        {
            ValidateData(model);

            return _repositoryManager
                .Repository<Persistance.Entities.Aliment>()
                .Insert(_mapper.Map<Persistance.Entities.Aliment>(model));
        }

        public object Update(AlimentModel model)
        {
            ValidateData(model);

            _repositoryManager
                .Repository<Persistance.Entities.Aliment>()
                .Update(
                    o => o.Id == model.Id,
                    _mapper.Map<Persistance.Entities.Aliment>(model)
                );

            return null; 
        }

        public object RemoveById(int id)
        {
            _repositoryManager
                .Repository<Persistance.Entities.Aliment>()
                .Delete(o => o.Id == id);
            return null;
        }

        #endregion
    }
}
