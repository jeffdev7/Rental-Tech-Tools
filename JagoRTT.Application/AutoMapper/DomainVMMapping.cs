using AutoMapper;
using JagoRTT.Application.ViewModel;
using JagoRTT.domain.Entities;

namespace JagoRTT.Application.AutoMapper
{
    public class DomainVMMapping : Profile
    {
        public DomainVMMapping()
        {
            CreateMap<Company, CompanyVM>();
            CreateMap<Tool, ToolVM>();
            CreateMap<Rental, RentalVM>();
            CreateMap<Employee, EmployeeVM>();

        }

    }
}
