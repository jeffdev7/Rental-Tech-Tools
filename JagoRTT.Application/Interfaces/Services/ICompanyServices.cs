using FluentValidation.Results;
using JagoRTT.Application.ViewModel;
using JagoRTT.domain.Entities;


namespace JagoRTT.Application.Interfaces.Services
{
    public interface ICompanyServices : IDisposable
    {
        IEnumerable<CompanyVM> GetAll();
        CompanyVM GetById(Guid id);
        IEnumerable<CompanyVM> GetAllBy(Func<Company, bool> exp);
        ValidationResult Add(CompanyVM vm);
        ValidationResult Update(CompanyVM vm);
        ValidationResult Remove(Guid id);
        IEnumerable<CompanyVM> GetCia();
    }
}
