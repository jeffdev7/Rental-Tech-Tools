using FluentValidation.Results;
using JagoRTT.Application.ViewModel;
using JagoRTT.domain.Entities;


namespace JagoRTT.Application.Interfaces.Services
{
    public interface IToolServices
    {
        IEnumerable<ToolVM> GetAll();
        ToolVM GetById(Guid id);
        IEnumerable<ToolVM> GetAllBy(Func<Tool, bool> exp);
        ValidationResult Add(ToolVM vm);
        ValidationResult Update(ToolVM vm);
        ValidationResult Remove(Guid id);
        IEnumerable<ToolVM> GetTools();
    }
}
