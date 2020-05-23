using Application.Meal.Interface;
using Application.Meal.DataModel.Sended;
using DataValidator;
using AutoMapper;
using RepositoryManager;

namespace Application.Meal
{
    public class MealCommand : App, IMealCommand 
    {
        #region Properties and Constructor

        public MealCommand(
            IRepositoryManager repositoryManager,
            IDataValidator dataValidator,
            IMapper mapper
        ) : base(repositoryManager, dataValidator, mapper)
        { }

        #endregion

        #region IMealCommand implementation

        public object Add(MealModel model)
        {
            ValidateData(model);

            Persistance.Entities.Meal meal = _repositoryManager
                .Repository<Persistance.Entities.Meal>()
                .Insert(_mapper.Map<Persistance.Entities.Meal>(model));

            model.Aliments.ForEach(aliment =>
            {
                _repositoryManager
                    .Repository<Persistance.Entities.MealXAliment>()
                    .Insert(new Persistance.Entities.MealXAliment() {
                        MealId = meal.Id,
                        AlimentId = aliment.Id.Value,
                        Quantity = aliment.Quantity
                    });
            });
            
            return meal;
        }

        public object Update(MealModel model)
        {
            ValidateData(model);

            _repositoryManager
                .Repository<Persistance.Entities.Meal>()
                .Update(
                    o => o.Id == model.Id,
                    _mapper.Map<Persistance.Entities.Meal>(model)
                );

            return null; 
        }

        public object RemoveById(int id)
        {
            _repositoryManager
                .Repository<Persistance.Entities.Meal>()
                .Delete(o => o.Id == id);
            return null;
        }

        #endregion
    }
}
