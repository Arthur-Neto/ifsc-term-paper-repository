using System;
using AutoMapper;
using ifsc.tcc.Portal.Domain.CommonModule;

namespace ifsc.tcc.Portal.Application
{
    public abstract class BaseAppService<TRepository>
    {
        protected readonly Lazy<IUnitOfWork> UnitOfWork;
        protected readonly Lazy<IMapper> Mapper;
        protected readonly TRepository Repository;

        public BaseAppService(TRepository repository)
        {
            Repository = repository;
        }

        public BaseAppService(
            Lazy<IUnitOfWork> unitOfWork,
            Lazy<IMapper> mapper,
            TRepository repository)
            : this(repository)
        {
            UnitOfWork = unitOfWork;
            Mapper = mapper;
        }
    }
}
