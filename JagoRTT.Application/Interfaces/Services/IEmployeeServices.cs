using FluentValidation.Results;
using JagoRTT.Application.ViewModel;
using JagoRTT.domain.Entities;
using JagoRTT.domain.Model;

namespace JagoRTT.Application.Interfaces.Services
{
    public interface IEmployeeServices
    {
        IEnumerable<EmployeeVM> GetAll();
        EmployeeVM GetById(Guid id);
        IEnumerable<EmployeeVM> GetAllBy(Func<Employee, bool> exp);
        Task<EmployeeVM> Update(EmployeeVM vm);
        Task<EmployeeVM> Add(EmployeeVM vm);
        Task<bool> Remove(Guid id);
        IEnumerable<ToolListModel> GetToolList();
        IEnumerable<CompanyListModel> GetCompanyList();
        IEnumerable<RentalListModel> GetRentalList();

        //extras
        IEnumerable<ToolVM> GetTools();
        IEnumerable<CompanyVM> GetCompanies();
        IEnumerable<RentalVM> GetRental();

    }
}
