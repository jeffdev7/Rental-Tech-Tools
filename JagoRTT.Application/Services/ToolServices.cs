using AutoMapper;
using FluentValidation.Results;
using JagoRTT.Application.Interfaces.Services;
using JagoRTT.Application.ViewModel;
using JagoRTT.domain.Entities;
using JagoRTT.domain.Interfaces.Repositories;
using JagoRTT.domain.Validator;

namespace JagoRTT.Application.Services
{
    public class ToolServices : IToolServices
    {
        private readonly IMapper _mapper;
        private readonly IToolRepository _toolRepository;

        public ToolServices(IMapper mapper, IToolRepository toolRepository)
        {
            _mapper = mapper;
            _toolRepository = toolRepository;
        }
        public IEnumerable<ToolVM> GetAll()
        {
            return _mapper.Map<IEnumerable<ToolVM>>(_toolRepository.GetAll());
        }

        public ToolVM GetById(Guid id)
        {
            return _mapper.Map<ToolVM>(_toolRepository.GetById(id));
        }
        public IEnumerable<ToolVM> GetAllBy(Func<Tool, bool> exp)
        {
            return _mapper.Map<IEnumerable<ToolVM>>(_toolRepository.GetAllBy(exp));

        }
        public ValidationResult Add(ToolVM vm)
        {
            var entity = _mapper.Map<Tool>(vm);
            var validationResult = new ToolValidator().Validate(entity);
            if (validationResult.IsValid)
                _toolRepository.Add(entity);

            return validationResult;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public IEnumerable<ToolVM> GetTools()
        {
            return _mapper.Map<IEnumerable<ToolVM>>(_toolRepository.GetTools());
        }

        public ValidationResult Remove(Guid id)
        {
            var entity = _toolRepository.GetById(id);
            var validationResult = new ToolValidator().Validate(entity);
            if (validationResult.IsValid)
                _toolRepository.Remove(id);
   
            return validationResult;
        }

        public ValidationResult Update(ToolVM vm)
        {
            var entity = _mapper.Map<Tool>(vm);
            var validationResult = new ToolValidator().Validate(entity);

            if (validationResult.IsValid)
            {
                _toolRepository.Update(entity);
            }

            return validationResult;
        }
    }
}
