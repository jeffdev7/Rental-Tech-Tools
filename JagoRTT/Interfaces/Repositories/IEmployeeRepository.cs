using JagoRTT.domain.Entities;

namespace JagoRTT.domain.Interfaces.Repositories
{
    public interface IEmployeelRepository : IRepository<Employee>
    {
        
        IQueryable<Company> GetCia();
        IQueryable<Tool> GetTools();
        IQueryable<Rental> GetRental();
        bool IsValidCompanyId(Guid companyId);
        bool IsValidToolId(Guid toolId);
        bool IsValidRentalId(Guid rentalId);
        //IQueryable<CompanyListModel> GetCompanyList();
        //IQueryable<ToolListModel> GetToolList();
        //IQueryable<RentalListModel> GetRentalList();
    }
}
