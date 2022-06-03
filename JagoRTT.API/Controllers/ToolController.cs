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
    public class ToolController : Controller
    {
        private readonly IToolServices _toolServices;

        public ToolController(IToolServices toolServices)
        {
            _toolServices = toolServices;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var status = await _toolServices.Remove(id);
            if (!status) return BadRequest();
            return Ok(status);

        }

        [HttpPost]
        public async Task<ActionResult<ToolVM>> Add([FromBody] ToolVM vm)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var cia = await _toolServices.Add(vm);
            return Ok(cia);

        }

        [HttpGet("{id}")]
        public async Task<ToolVM> GetById(Guid id)
        {
            return _toolServices.GetById(id);
        }

       
        [HttpGet]
        public async Task<IEnumerable<ToolVM>> GetCompanies()
        {
             return _toolServices.GetAll().OrderByDescending(_ => _.QuantityInStock);
           
         
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ToolVM>> Update([FromBody] ToolVM vm)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var cia = await _toolServices.Update(vm);
            return Ok(cia);

        }

        [HttpGet("GetToolByBrand")]
        public async Task<IEnumerable<EnumTypeVM>> GetToolByBrand()
        {
            return new List<EnumTypeVM>() {
                new EnumTypeVM("HP", Convert.ToString((int)EBrand.HP)),
                new EnumTypeVM("DELL", Convert.ToString((int)EBrand.DELL)),
                new EnumTypeVM("LENOVO", Convert.ToString((int)EBrand.LENOVO)),
                new EnumTypeVM("MACBOOK", Convert.ToString((int)EBrand.APPLE)),

            };
        }

    }
}
