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
        ValidationResult Add(EmployeeVM vm);
        ValidationResult Update(EmployeeVM vm);
        ValidationResult Remove(Guid id);
        IEnumerable<ToolListModel> GetToolList();
        IEnumerable<CompanyListModel> GetCompanyList();
    }
}
