using AutoMapper;
using FluentValidation.Results;
using JagoRTT.Application.Interfaces.Services;
using JagoRTT.Application.ViewModel;
using JagoRTT.domain.Entities;
using JagoRTT.domain.Interfaces.Repositories;
using JagoRTT.domain.Model;
using JagoRTT.domain.Validator;
using JagoRTT.Infrastructure.DBConfiguration;
using Microsoft.EntityFrameworkCore;

namespace JagoRTT.Application.Services
{
    public class EmployeeServices : IEmployeeServices
    {
        private readonly IMapper _mapper;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ApplicationContext _context;

        public EmployeeServices(IMapper mapper, IEmployeeRepository employeeRepository, ApplicationContext context)
        {
            _mapper = mapper;
            _employeeRepository = employeeRepository;
            _context = context;
        }
        /// <summary>
        /// Business Logic
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ToolListModel> GetToolList()
        {
            return _employeeRepository.GetToolList();
        }
        public IEnumerable<CompanyListModel> GetCompanyList()
        {
            return _employeeRepository.GetCompanyList();
        }
        public IEnumerable<RentalListModel> GetRentalList()
        {
            return _employeeRepository.GetRentalList();
        }

        public IEnumerable<EmployeeVM> GetAll()
        {
            var employeeData = _employeeRepository.GetAll()
                 .Include(_ => _.Tool).Include(_=>_.Company)
                 .Include(_=>_.Rental)
                 .Select(_ => new EmployeeVM
                 {
                     Id = _.Id,
                     Name = _.Name,
                     CPF = _.CPF,
                     Email = _.Email,
                     Phone = _.Phone,
                     CompanyId = _.CompanyId,
                     CiaName = _.Company.Name,//for UI
                     ToolId = _.ToolId,
                     ToolName = _.Tool.Name,//for UI
                     RentalId = _.RentalId,
                     RentalType = _.Rental.Type//for UI

                 }).AsNoTracking();
            Dispose();
            return employeeData;
        }
        /// <summary>
        /// Business Logic
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        public EmployeeVM GetById(Guid id)
        {
            return _mapper.Map<EmployeeVM>(_employeeRepository.GetById(id));
        }
        public IEnumerable<EmployeeVM> GetAllBy(Func<Employee, bool> exp)
        {
            return _mapper.Map<IEnumerable<EmployeeVM>>(_employeeRepository.GetAllBy(exp));

        }
        public async Task<EmployeeVM> Add(EmployeeVM vm)
        {
            Employee employee = _mapper.Map<Employee>(vm);
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
            return _mapper.Map<EmployeeVM>(employee);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public async Task<bool> Remove(Guid id)
        {
            Employee employee = await _context.Employees.Where(p => p.Id == id)
                    .FirstOrDefaultAsync();
            if (employee == null) return false;
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<EmployeeVM> Update(EmployeeVM vm)
        {
            Employee employee = _mapper.Map<Employee>(vm);
            _context.Employees.Update(employee);
            await _context.SaveChangesAsync();
            return _mapper.Map<EmployeeVM>(employee);
        }
        //extras
        public IEnumerable<ToolVM> GetTools()
        {
            return _mapper.Map<IEnumerable<ToolVM>>(_employeeRepository.GetTools());
        }
        public IEnumerable<CompanyVM> GetCompanies()
        {
            return _mapper.Map<IEnumerable<CompanyVM>>(_employeeRepository.GetCompany());
        }
        public IEnumerable<RentalVM> GetRental()
        {
            return _mapper.Map<IEnumerable<RentalVM>>(_employeeRepository.GetRental());
        }

    }
}
