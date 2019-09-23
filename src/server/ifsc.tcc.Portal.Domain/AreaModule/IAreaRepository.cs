using ifsc.tcc.Portal.Domain.CommonModule;

namespace ifsc.tcc.Portal.Domain.AreaModule
{
    public interface IAreaRepository
        : IGetRepository<Area>,
        IAddRepository<Area>
    { }
}
