using JagoRTT.domain.Entities;
using JagoRTT.domain.Interfaces.Repositories;
using JagoRTT.domain.Model;
using JagoRTT.Infrastructure.DBConfiguration;

namespace JagoRTT.Infrastructure.Repositories
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(ApplicationContext context) : base(context)
        {
        }

        public IQueryable<Company> GetCia()
        {
            return Db.Companies;
        }

        public IQueryable<Rental> GetRental()
        {
            return Db.Rentals;
        }

        public IQueryable<Tool> GetTools()
        {
            return Db.Tools;
        }

        public bool IsValidCompanyId(Guid companyId)
        {
            return Db.Companies.Any(_ => _.Id == companyId);
        }

        public bool IsValidRentalId(Guid rentalId)
        {
            return Db.Rentals.Any(_ => _.Id == rentalId);
        }

        public bool IsValidToolId(Guid toolId)
        {
            return Db.Tools.Any(_ => _.Id == toolId);
        }

        public IQueryable<CompanyListModel> GetCompanyList()
        {
            return Db.Companies.Select(j => new CompanyListModel { Id = j.Id, Name = j.Name }).AsQueryable();
        }
        public IQueryable<RentalListModel> GetRentalList()
        {
            return Db.Rentals.Select(j => new RentalListModel { Id = j.Id, Type = j.Type }).AsQueryable();
        }
        public IQueryable<ToolListModel> GetToolList()
        {
            return Db.Tools.Select(j => new ToolListModel { Id = j.Id, Name = j.Name }).AsQueryable();
        }
    }
}
