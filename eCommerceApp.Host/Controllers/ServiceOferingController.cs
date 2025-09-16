using eCommerceApp.Application.DTOs.ServicioAhora.ServOffering;
using eCommerceApp.Application.Services.Interfaces.ServcioAhora;
using Microsoft.AspNetCore.Mvc;

namespace eCommerceApp.Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceOferingController(IServiceOfferingService serviceOfferingService) : ControllerBase
    {
        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            var data = await serviceOfferingService.GetAllAsync();
            return data.Any() ? Ok(data) : NotFound(data);
        }

        [HttpGet("single/{id}")]
        public async Task<IActionResult> GetSingle(Guid id)
        {
            var data = await serviceOfferingService.GetByIdAsync(id);
            return data != null ? Ok(data) : NotFound(data);
        }

        [HttpPost("add")]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> Add(CreateServiceOffering serviceOffering)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var result = await serviceOfferingService.AddAsync(serviceOffering);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPut("update")]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(UpdateServiceOffering serviceOffering)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var result = await serviceOfferingService.UpdateAsync(serviceOffering);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        //[HttpDelete("delete/{id}")]
        ////[Authorize(Roles = "Admin")]
        //public async Task<IActionResult> Delte(Guid id)
        //{
        //    var result = await productService.DeleteAsync(id);
        //    return result.Success ? Ok(result) : BadRequest(result);
        //}
    }
}
