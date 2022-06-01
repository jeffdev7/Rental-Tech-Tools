using JagoRTT.domain.Entities;

namespace JagoRTT.domain.Interfaces.Repositories
{
    public interface IToolRepository : IRepository<Tool>
    {
        IQueryable<Tool> GetTools();
    }
}
