using AutoMapper;
using DataValidator;
using RepositoryManager;
using System;

namespace Application
{
    public class App
    {
        #region Properties and Constructor

        protected readonly IRepositoryManager _repositoryManager;
        protected readonly IDataValidator _dataValidator;
        protected readonly IMapper _mapper;

        public App(
            IRepositoryManager repositoryManager,
            IDataValidator dataValidator,
            IMapper mapper
        )
        {
            _repositoryManager = repositoryManager;
            _dataValidator = dataValidator;
            _mapper = mapper;
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
