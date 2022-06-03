using JagoRTT.Application.ViewModel;
using JagoRTT.domain.Entities;


namespace JagoRTT.Application.Interfaces.Services
{
    public interface ICompanyServices : IDisposable
    {
        IEnumerable<CompanyVM> GetAll();
        CompanyVM GetById(Guid id);
        IEnumerable<CompanyVM> GetAllBy(Func<Company, bool> exp);
        Task<CompanyVM> Update(CompanyVM vm);
        Task<CompanyVM> Add(CompanyVM vm);
        Task<bool> Remove(Guid id);
        IEnumerable<CompanyVM> GetCia();
    }
}
