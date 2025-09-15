using eCommerceApp.Application.DTOs.Identity.Rol.Professional;
using eCommerceApp.Application.DTOs.Product;
using eCommerceApp.Application.Services.Interfaces.Rol;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eCommerceApp.Host.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ProfessionalController(IProfessionalService professionalService) : ControllerBase
    {
        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            var data = await professionalService.GetAllAsync();
            return data.Any() ? Ok(data) : NotFound(data);
        }

        [HttpGet("single/{id}")]
        public async Task<IActionResult> GetSingle(string id)
        {
            var data = await professionalService.GetByIdAsync(id);
            return data != null ? Ok(data) : NotFound(data);
        }

        [HttpPut("update")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(UpdateProfessional professional)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var result = await professionalService.UpdateAsync(professional);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        //[HttpDelete("delete/{id}")]
        //[Authorize(Roles = "Admin")]
        //public async Task<IActionResult> Delte(Guid id)
        //{
        //    var result = await productService.DeleteAsync(id);
        //    return result.Success ? Ok(result) : BadRequest(result);
        //}
    }
}
