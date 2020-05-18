using System;
using DataValidator;
using AutoMapper;
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

        #region Protected Methods

        protected void ValidateData<DataForm>(DataForm data)
        {
            Exception exception = _dataValidator.Validate(data);
            if (exception != null) throw exception;
        }

        #endregion
    }
}
