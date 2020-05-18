using System;
using DataValidator;
using AutoMapper;
using System.Reflection;
using RepositoryManager;

namespace Application
{
    public class Command : App 
    {
        #region Properties and Constructor

        protected readonly IDataValidator _dataValidator;

        public Command(
            IRepositoryManager repositoryManager,
            IDataValidator dataValidator,
            IMapper mapper
        ) : base(repositoryManager, mapper)
        {
            _dataValidator = dataValidator;
        }

        #endregion

        #region Private Methods

        private void FillUpdate<Entity>(object obj, Entity toObject)
        {
            Type toObjectType = toObject.GetType();
            PropertyInfo[] props = toObjectType.GetProperties();
            foreach (PropertyInfo prop in props)
            {
                PropertyInfo objProp = obj.GetType().GetProperty(prop.Name);
                if (objProp != null)
                {
                    object value = objProp.GetValue(obj);
                    if (value != null)
                        prop.SetValue(toObject, value);
                }
            }
        }

        #endregion

        #region Protected Methods

        protected Entity Insert<Entity,DataForm>(DataForm dataform)
            where Entity : class, new()
            where DataForm : class
        {
            Exception exception = _dataValidator.Validate(dataform);
            if (exception != null) throw exception;

            return _repositoryManager
                .Repository<Entity>()
                .Insert(_mapper.Map<Entity>(dataform));
        }

        protected void Update<Entity,DataForm>(DataForm dataForm, Func<Entity, bool> predicate)
            where Entity : class, new()
            where DataForm : class
        {
            Exception exception = _dataValidator.Validate(dataForm);
            if (exception != null) throw exception;

            _repositoryManager
                .Repository<Entity>()
                .Update(
                    o => predicate(o),
                   _mapper.Map<Entity>(dataForm)
                );
        }

        #endregion
    }
}
