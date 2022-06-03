using JagoRTT.Application.Interfaces.Services;
using JagoRTT.Application.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace JagoRTT.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CompanyController : Controller
    {
        private readonly ICompanyServices _ciaServices;

        public CompanyController(ICompanyServices ciaServices)
        {
            _ciaServices = ciaServices;
        }
       
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var status = await _ciaServices.Remove(id);
            if (!status) return BadRequest();
            return Ok(status);

        }

        [HttpPost]
        public async Task<ActionResult<CompanyVM>> Add([FromBody] CompanyVM vm)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var cia = await _ciaServices.Add(vm);
            return Ok(cia);

        }

        [HttpGet("{id}")]
        public async Task<CompanyVM> GetById(Guid id)
        {
            return _ciaServices.GetById(id);
        }

       
        [HttpGet]
        public async Task<IEnumerable<CompanyVM>> GetCompanies()
        {
             return _ciaServices.GetAll().OrderBy(_ => _.Name);

        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CompanyVM>> Update([FromBody] CompanyVM vm)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var cia = await _ciaServices.Update(vm);
            return Ok(cia);

        }

    }
}
