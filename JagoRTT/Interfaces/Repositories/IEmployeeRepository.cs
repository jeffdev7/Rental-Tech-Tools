using JagoRTT.domain.Entities;
using JagoRTT.domain.Model;

namespace JagoRTT.domain.Interfaces.Repositories
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        
        IQueryable<Company> GetCompany();
        IQueryable<Tool> GetTools();
        IQueryable<Rental> GetRental();
        bool IsValidCompanyId(Guid companyId);
        bool IsValidToolId(Guid toolId);
        bool IsValidRentalId(Guid rentalId);
        IQueryable<CompanyListModel> GetCompanyList();
        IQueryable<ToolListModel> GetToolList();
        IQueryable<RentalListModel> GetRentalList();
    }
}
