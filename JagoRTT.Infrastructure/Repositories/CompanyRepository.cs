using JagoRTT.domain.Entities;
using JagoRTT.domain.Interfaces.Repositories;
using JagoRTT.Infrastructure.DBConfiguration;

namespace JagoRTT.Infrastructure.Repositories
{
    public class CompanyRepository : Repository<Company>, ICompanyRepository
    {
        public CompanyRepository(ApplicationContext context): base(context) { }
        public IQueryable<Company> GetCia()
        {
            return Db.Companies;
        }
    }
}
