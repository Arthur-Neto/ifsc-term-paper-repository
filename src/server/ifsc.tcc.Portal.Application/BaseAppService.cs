namespace ifsc.tcc.Portal.Application
{
    public abstract class BaseAppService<TRepository>
    {
        protected TRepository Repository;

        public BaseAppService(TRepository repository)
        {
            Repository = repository;
        }
    }
}
