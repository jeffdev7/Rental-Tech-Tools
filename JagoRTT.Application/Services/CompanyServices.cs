using AutoMapper;
using FluentValidation.Results;
using JagoRTT.Application.Interfaces.Services;
using JagoRTT.Application.ViewModel;
using JagoRTT.domain.Entities;
using JagoRTT.domain.Interfaces.Repositories;
using JagoRTT.domain.Validator;

namespace JagoRTT.Application.Services
{
    public class CompanyServices : ICompanyServices
    {
        private readonly IMapper _mapper;
        private readonly ICompanyRepository _ciaRepository;

        public CompanyServices(IMapper mapper, ICompanyRepository ciaRepository)
        {
            _mapper = mapper;
            _ciaRepository = ciaRepository;
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
        public ValidationResult Add(CompanyVM vm)
        {
            var entity = _mapper.Map<Company>(vm);
            var validationResult = new CompanyValidator().Validate(entity);
            if (validationResult.IsValid)
                _ciaRepository.Add(entity);

            return validationResult;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public IEnumerable<CompanyVM> GetCia()
        {
            return _mapper.Map<IEnumerable<CompanyVM>>(_ciaRepository.GetCia());
        }

        public ValidationResult Remove(Guid id)
        {
            var entity = _ciaRepository.GetById(id);
            var validationResult = new CompanyValidator().Validate(entity);
            if (validationResult.IsValid)
                _ciaRepository.Remove(id);
   
            return validationResult;
        }

        public ValidationResult Update(CompanyVM vm)
        {
            var entity = _mapper.Map<Company>(vm);
            var validationResult = new CompanyValidator().Validate(entity);

            if (validationResult.IsValid)
            {
                _ciaRepository.Update(entity);
            }

            return validationResult;
        }
    }
}
