using FluentValidation.Results;
using JagoRTT.Application.ViewModel;
using JagoRTT.domain.Entities;
using JagoRTT.domain.Model;

namespace JagoRTT.Application.Interfaces.Services
{
    public interface IRentalServices
    {
        IEnumerable<RentalVM> GetAll();
        RentalVM GetById(Guid id);
        IEnumerable<RentalVM> GetAllBy(Func<Rental, bool> exp);
        ValidationResult Add(RentalVM vm);
        ValidationResult Update(RentalVM vm);
        ValidationResult Remove(Guid id);
        IEnumerable<ToolListModel> GetToolList();
        IEnumerable<CompanyListModel> GetCompanyList();
        IEnumerable<RentalVM> GetRentedToolByDate();    
    }
}
