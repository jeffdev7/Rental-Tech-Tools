using AutoMapper;
using FluentValidation.Results;
using JagoRTT.Application.Interfaces.Services;
using JagoRTT.Application.ViewModel;
using JagoRTT.domain.Entities;
using JagoRTT.domain.Interfaces.Repositories;
using JagoRTT.domain.Validator;
using JagoRTT.Infrastructure.DBConfiguration;
using Microsoft.EntityFrameworkCore;

namespace JagoRTT.Application.Services
{
    public class ToolServices : IToolServices
    {
        private readonly IMapper _mapper;
        private readonly IToolRepository _toolRepository;
        private readonly ApplicationContext _context;

        public ToolServices(IMapper mapper, IToolRepository toolRepository, ApplicationContext context)
        {
            _mapper = mapper;
            _toolRepository = toolRepository;
            _context = context; 
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
        //public ValidationResult Add(ToolVM vm)
        //{
        //    var entity = _mapper.Map<Tool>(vm);
        //    var validationResult = new ToolValidator().Validate(entity);
        //    if (validationResult.IsValid)
        //        _toolRepository.Add(entity);

        //    return validationResult;
        //}

        public async Task<ToolVM> Add(ToolVM vm)
        {
            Tool tool = _mapper.Map<Tool>(vm);
            _context.Tools.Add(tool);
            await _context.SaveChangesAsync();
            return _mapper.Map<ToolVM>(tool);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public IEnumerable<ToolVM> GetTools()
        {
            return _mapper.Map<IEnumerable<ToolVM>>(_toolRepository.GetTools());
        }

        public async Task<bool> Remove(Guid id)
        {
            Tool tool = await _context.Tools.Where(p => p.Id == id)
                    .FirstOrDefaultAsync();
            if (tool == null) return false;
            _context.Tools.Remove(tool);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<ToolVM> Update(ToolVM vm)
        {
            Tool tool = _mapper.Map<Tool>(vm);
            _context.Tools.Update(tool);
            await _context.SaveChangesAsync();
            return _mapper.Map<ToolVM>(tool);
        }

        //public ValidationResult Remove(Guid id)
        //{
        //    var entity = _toolRepository.GetById(id);
        //    var validationResult = new ToolValidator().Validate(entity);
        //    if (validationResult.IsValid)
        //        _toolRepository.Remove(id);

        //    return validationResult;
        //}

        //public ValidationResult Update(ToolVM vm)
        //{
        //    var entity = _mapper.Map<Tool>(vm);
        //    var validationResult = new ToolValidator().Validate(entity);

        //    if (validationResult.IsValid)
        //    {
        //        _toolRepository.Update(entity);
        //    }

        //    return validationResult;
        //}
    }
}
