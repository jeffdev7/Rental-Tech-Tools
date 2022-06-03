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
        Task<ToolVM> Update(ToolVM vm);
        Task<ToolVM> Add(ToolVM vm);
        Task<bool> Remove(Guid id);
        IEnumerable<ToolVM> GetTools();
    }
}
