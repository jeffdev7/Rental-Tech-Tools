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
    public class RentalServices : IRentalServices
    {
        private readonly IMapper _mapper;
        private readonly IRentalRepository _rentalRepository;

        public RentalServices(IMapper mapper, IRentalRepository rentalRepository)
        {
            _mapper = mapper;
            _rentalRepository = rentalRepository;
        }

        /// <summary>
        /// business logic
        /// </summary>
        public IEnumerable<ToolListModel> GetToolList()
        {
            return _rentalRepository.GetToolList();
        }
        public IEnumerable<CompanyListModel> GetCompanyList()
        {
            return _rentalRepository.GetCompanyList();
        }

        public IEnumerable<RentalVM> GetAll()
        {
           var rental = _rentalRepository.GetAll()
                .Include(_ => _.Tool)
                .Select(_ => new RentalVM
                {
                    Id = _.Id,
                    BeginDate = _.BeginDate,
                    EndDate = _.EndDate,
                    Price = _.Price,
                    Type = _.Type,
                    ToolId = _.ToolId,
                    ToolName = _.Tool.Name,
                    CompanyId = _.CompanyId,
                    CiaName = _.Company.Name

                }).AsNoTracking();
            Dispose();
            return rental;
        }

        public IEnumerable<RentalVM> GetRentedToolByDate()
        {
            var tool = _rentalRepository.GetAll().OrderBy(_ => _.BeginDate)
                .Include(_ => _.Tool)
                .Select(_ => new RentalVM
                {
                    Id = _.Id,
                    BeginDate = _.BeginDate,
                    EndDate = _.EndDate,
                    Price = _.Price,
                    Type = _.Type,
                    ToolId = _.ToolId,
                    ToolName = _.Tool.Name,
                    CompanyId = _.CompanyId,
                    CiaName = _.Company.Name
                }).AsNoTracking();
            Dispose();
            return tool;
        }
        /// <summary>
        /// Business logic
        /// </summary>
        /// 
        public RentalVM GetById(Guid id)
        {
            return _mapper.Map<RentalVM>(_rentalRepository.GetById(id));
        }
        public IEnumerable<RentalVM> GetAllBy(Func<Rental, bool> exp)
        {
            return _mapper.Map<IEnumerable<RentalVM>>(_rentalRepository.GetAllBy(exp));

        }
        public ValidationResult Add(RentalVM vm)
        {
            var entity = _mapper.Map<Rental>(vm);
            var validationResult = new RentalValidator().Validate(entity);
            if (validationResult.IsValid)
                _rentalRepository.Add(entity);

            return validationResult;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public ValidationResult Remove(Guid id)
        {
            var entity = _rentalRepository.GetById(id);
            var validationResult = new RentalValidator().Validate(entity);
            if (validationResult.IsValid)
                _rentalRepository.Remove(id);
   
            return validationResult;
        }

        public ValidationResult Update(RentalVM vm)
        {
            var entity = _mapper.Map<Rental>(vm);
            var validationResult = new RentalValidator().Validate(entity);

            if (validationResult.IsValid)
            {
                _rentalRepository.Update(entity);
            }

            return validationResult;
        }
    }
}
