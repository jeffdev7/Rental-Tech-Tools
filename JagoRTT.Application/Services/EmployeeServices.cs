using AutoMapper;
using FluentValidation.Results;
using JagoRTT.Application.Interfaces.Services;
using JagoRTT.Application.ViewModel;
using JagoRTT.domain.Entities;
using JagoRTT.domain.Interfaces.Repositories;
using JagoRTT.domain.Model;
using JagoRTT.domain.Validator;
using Microsoft.EntityFrameworkCore;

namespace JagoRTT.Application.Services
{
    public class EmployeeServices : IEmployeeServices
    {
        private readonly IMapper _mapper;
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeServices(IMapper mapper, IEmployeeRepository employeeRepository)
        {
            _mapper = mapper;
            _employeeRepository = employeeRepository;
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

        public IEnumerable<EmployeeVM> GetAll()
        {
            var employeeData = _employeeRepository.GetAll()
                 .Include(_ => _.Tool)
                 .Select(_ => new EmployeeVM
                 {
                     Id = _.Id,
                     Name = _.Name,
                     CPF = _.CPF,
                     Email = _.Email,
                     Phone = _.Phone,
                     CompanyId = _.CompanyId,
                     CiaName = _.Company.Name,
                     ToolId = _.ToolId,
                     ToolName = _.Tool.Name,
                     RentalId = _.RentalId,
                     RentalType = _.Rental.Type

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
        public ValidationResult Add(EmployeeVM vm)
        {
            var entity = _mapper.Map<Employee>(vm);
            var validationResult = new EmployeeValidator().Validate(entity);
            if (validationResult.IsValid)
                _employeeRepository.Add(entity);

            return validationResult;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public ValidationResult Remove(Guid id)
        {
            var entity = _employeeRepository.GetById(id);
            var validationResult = new EmployeeValidator().Validate(entity);
            if (validationResult.IsValid)
                _employeeRepository.Remove(id);
   
            return validationResult;
        }

        public ValidationResult Update(EmployeeVM vm)
        {
            var entity = _mapper.Map<Employee>(vm);
            var validationResult = new EmployeeValidator().Validate(entity);

            if (validationResult.IsValid)
            {
                _employeeRepository.Update(entity);
            }

            return validationResult;
        }
    }
}
