using AutoMapper;
using JagoRTT.Application.ViewModel;
using JagoRTT.domain.Entities;

namespace JagoRTT.Application.AutoMapper
{
    public class VMDomainMapping : Profile
    {
        public VMDomainMapping()
        {
            CreateMap<CompanyVM, Company>();
            CreateMap<ToolVM, Tool>();
            CreateMap<RentalVM, Rental>();
            CreateMap<EmployeeVM, Employee>();
        }
    }
}
