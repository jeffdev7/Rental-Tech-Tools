using JagoRTT.Application.Interfaces.Services;
using JagoRTT.Application.ViewModel;
using JagoRTT.domain.Entities.Enum;
using JagoRTT.domain.Enum.VM;
using JagoRTT.Infrastructure.DBConfiguration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JagoRTT.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeServices _employeeServices;

        public EmployeeController(IEmployeeServices employeeServices)
        {
            _employeeServices = employeeServices;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var status = await _employeeServices.Remove(id);
            if (!status) return BadRequest();
            return Ok(status);

        }

        [HttpPost]
        public async Task<ActionResult<EmployeeVM>> Add([FromBody] EmployeeVM vm)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var cia = await _employeeServices.Add(vm);
            return Ok(cia);

        }

        [HttpGet("{id}")]
        public async Task<EmployeeVM> GetById(Guid id)
        {
            return _employeeServices.GetById(id);
        }

        [HttpGet]
        public async Task<IEnumerable<EmployeeVM>> GetEmployees()
        {
            return _employeeServices.GetAll().OrderBy(_ => _.Name);

        }

        [HttpPut("{id}")]
        public async Task<ActionResult<EmployeeVM>> Update([FromBody] EmployeeVM vm)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var cia = await _employeeServices.Update(vm);
            return Ok(cia);

        }

        [HttpGet("GetRentedToolByEmployee")]
        public async Task<IEnumerable<ToolVM>> GetTools()
        {
            return _employeeServices.GetTools();

        }
        [HttpGet("GetCompanyOfEmployee")]
        public async Task<IEnumerable<CompanyVM>> GetCompanies()
        {
            return _employeeServices.GetCompanies();

        }
        [HttpGet("GetTypeOfRentalService")]
        public async Task<IEnumerable<RentalVM>> GetRental()
        {
            return _employeeServices.GetRental();

        }

    }
}
