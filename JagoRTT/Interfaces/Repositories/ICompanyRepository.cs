using JagoRTT.domain.Entities;

namespace JagoRTT.domain.Interfaces.Repositories
{
    public interface ICompanyRepository : IRepository<Company>
    {
        IQueryable<Company> GetCia();
    }
}
