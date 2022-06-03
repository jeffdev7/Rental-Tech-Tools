using JagoRTT.domain.Entities;
using JagoRTT.domain.Model;

namespace JagoRTT.domain.Interfaces.Repositories
{
    public interface IRentalRepository : IRepository<Rental>
    {
        
        IQueryable<Tool> GetTools();
        IQueryable<Company> GetCompanies();
        bool IsValidToolId(Guid toolId);
        bool IsValidCompanyId(Guid companyId);
       IQueryable<ToolListModel> GetToolList();
       IQueryable<CompanyListModel> GetCompanyList();
    }
}
