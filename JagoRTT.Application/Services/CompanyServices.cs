using AutoMapper;
using JagoRTT.Application.Interfaces.Services;
using JagoRTT.Application.ViewModel;
using JagoRTT.domain.Entities;
using JagoRTT.domain.Interfaces.Repositories;
using JagoRTT.Infrastructure.DBConfiguration;
using Microsoft.EntityFrameworkCore;

namespace JagoRTT.Application.Services
{
    public class CompanyServices : ICompanyServices
    {
        private readonly IMapper _mapper;
        private readonly ICompanyRepository _ciaRepository;
        private readonly ApplicationContext _context;

        public CompanyServices(IMapper mapper, ICompanyRepository ciaRepository, ApplicationContext context)
        {
            _mapper = mapper;
            _ciaRepository = ciaRepository;
            _context = context;
        }
        public IEnumerable<CompanyVM> GetAll()
        {
            return _mapper.Map<IEnumerable<CompanyVM>>(_ciaRepository.GetAll());
        }

        public CompanyVM GetById(Guid id)
        {
            return _mapper.Map<CompanyVM>(_ciaRepository.GetById(id));
        }
        public IEnumerable<CompanyVM> GetAllBy(Func<Company, bool> exp)
        {
            return _mapper.Map<IEnumerable<CompanyVM>>(_ciaRepository.GetAllBy(exp));

        }

        public async Task<CompanyVM> Add(CompanyVM vm)
        {
            Company cia = _mapper.Map<Company>(vm);
            _context.Companies.Add(cia);
            await _context.SaveChangesAsync();
            return _mapper.Map<CompanyVM>(cia);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public IEnumerable<CompanyVM> GetCia()
        {
            return _mapper.Map<IEnumerable<CompanyVM>>(_ciaRepository.GetCia());
        }

        public async Task<bool> Remove(Guid id)
        {
            Company cia = await _context.Companies.Where(p => p.Id == id)
                    .FirstOrDefaultAsync();
            if (cia == null) return false;
            _context.Companies.Remove(cia);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<CompanyVM> Update(CompanyVM vm)
        {  
            Company cia = _mapper.Map<Company>(vm);
            _context.Companies.Update(cia);
            await _context.SaveChangesAsync();
            return _mapper.Map<CompanyVM>(cia);
        }
    }
}
