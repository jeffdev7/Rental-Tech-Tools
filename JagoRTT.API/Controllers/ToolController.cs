using JagoRTT.Application.Interfaces.Services;
using JagoRTT.Application.ViewModel;
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
        public async Task<IActionResult> Delete(Guid id)
        {
             return (IActionResult)_toolServices.Remove(id);
           
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] ToolVM vm)
        {
           return (IActionResult)_toolServices.Add(vm);
            
        }

        [HttpGet("{id}")]
        public async Task<ToolVM> GetById(Guid id)
        {
            return _toolServices.GetById(id);
        }

       
        [HttpGet]
        public async Task<IEnumerable<ToolVM>> GetCompanies()
        {
             return _toolServices.GetAll().OrderBy(_ => _.Name);
           
         
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] ToolVM vm)
        {
            return (IActionResult)_toolServices.Update(vm);
        }

        //[HttpGet("GetToolTypeEnums")]
        //public async Task<IEnumerable<EnumTypeVm>> GetToolTypeEnums()
        //{
        //    return new List<EnumTypeVm>() {
        //        new EnumTypeVm("Cassino",Convert.ToString((int)EToolType.Casino)),
        //        new EnumTypeVm("Online",Convert.ToString((int)EToolType.Cloud)),
        //        new EnumTypeVm("Padrão",Convert.ToString((int)EToolType.Default)),
        //        new EnumTypeVm("Lan House",Convert.ToString((int)EToolType.LanHouse)),
        //        new EnumTypeVm("Outros",Convert.ToString((int)EToolType.Other)),
        //    };
        //}

    }
}
