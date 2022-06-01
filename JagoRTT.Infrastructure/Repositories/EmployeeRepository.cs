using JagoRTT.domain.Entities;
using JagoRTT.domain.Interfaces.Repositories;
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
        //TODO: Models here
    }
}
