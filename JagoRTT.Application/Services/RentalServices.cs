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
    public class RentalServices : IRentalServices
    {
        private readonly IMapper _mapper;
        private readonly IRentalRepository _rentalRepository;
        private readonly ApplicationContext _context;

        public RentalServices(IMapper mapper, IRentalRepository rentalRepository, ApplicationContext context)
        {
            _mapper = mapper;
            _rentalRepository = rentalRepository;
            _context = context;
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
                    ToolName = _.Tool.Name,//only for UI
                    CompanyId = _.CompanyId,
                   CiaName = _.Company.Name//only for UI

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
                    ToolName = _.Tool.Name,//only for UI
                    CompanyId = _.CompanyId,
                   CiaName = _.Company.Name //only for UI--it may not be needed
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
        public async Task<RentalVM> Add(RentalVM vm)
        {
            Rental rent = _mapper.Map<Rental>(vm);
            _context.Rentals.Add(rent);
            await _context.SaveChangesAsync();
            return _mapper.Map<RentalVM>(rent);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public async Task<bool> Remove(Guid id)
        {
            Rental rent = await _context.Rentals.Where(p => p.Id == id)
                    .FirstOrDefaultAsync();
            if (rent == null) return false;
            _context.Rentals.Remove(rent);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<RentalVM> Update(RentalVM vm)
        {
            Rental rent = _mapper.Map<Rental>(vm);
            _context.Rentals.Update(rent);
            await _context.SaveChangesAsync();
            return _mapper.Map<RentalVM>(rent);
        }
        //extras
        public IEnumerable<ToolVM> GetTools()
        {
            return _mapper.Map<IEnumerable<ToolVM>>(_rentalRepository.GetTools());
        }
        public IEnumerable<CompanyVM> GetCompanies()
        {
            return _mapper.Map<IEnumerable<CompanyVM>>(_rentalRepository.GetCompanies());
        }
    }
}
