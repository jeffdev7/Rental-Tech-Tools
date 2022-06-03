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
    public class RentalController : Controller
    {
        private readonly IRentalServices _rentalServices;

        public RentalController(IRentalServices rentalServices)
        {
            _rentalServices = rentalServices;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var status = await _rentalServices.Remove(id);
            if (!status) return BadRequest();
            return Ok(status);

        }

        [HttpPost]
        public async Task<ActionResult<RentalVM>> Add([FromBody] RentalVM vm)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var cia = await _rentalServices.Add(vm);
            return Ok(cia);

        }

        [HttpGet("{id}")]
        public async Task<RentalVM> GetById(Guid id)
        {
            return _rentalServices.GetById(id);
        }

        [HttpGet]
        public async Task<IEnumerable<RentalVM>> GetRentals()
        {
            return _rentalServices.GetAll().OrderBy(_ => _.BeginDate);

        }

        [HttpPut("{id}")]
        public async Task<ActionResult<RentalVM>> Update([FromBody] RentalVM vm)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var cia = await _rentalServices.Update(vm);
            return Ok(cia);

        }

        [HttpGet("GetRentedTools")]
        public async Task<IEnumerable<ToolVM>> GetTools()
        {
            return _rentalServices.GetTools();

        }
        [HttpGet("GetCompanyThatRentedTools")]
        public async Task<IEnumerable<CompanyVM>> GetCompanies()
        {
            return _rentalServices.GetCompanies();

        }

        [HttpGet("GetTypeOfRental")]
        public async Task<IEnumerable<EnumTypeVM>> GetTypeOfRental()
        {
            return new List<EnumTypeVM>() {
                new EnumTypeVM("Monthly", Convert.ToString((int)ETypeOfRental.Monthly)),
                new EnumTypeVM("Per Semester", Convert.ToString((int)ETypeOfRental.Semester)),
                new EnumTypeVM("Per Trimester", Convert.ToString((int)ETypeOfRental.Trimester)),
                new EnumTypeVM("Weekly", Convert.ToString((int)ETypeOfRental.Weekly)),


            };
        }

    }
}
