using eCommerceApp.Application.DTOs.Category;
using eCommerceApp.Application.DTOs.ProfessionalCat;
using eCommerceApp.Application.DTOs.ProfessionalLicense;
using eCommerceApp.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace eCommerceApp.Host.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ProfessionalCategoryController(IProfessionalCategoryService profCategoryService) : ControllerBase
    {
        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            var data = await profCategoryService.GetAllAsync();
            return data.Any() ? Ok(data) : NotFound(data);
        }

        [HttpGet("single/{id}")]
        public async Task<IActionResult> GetSingle(Guid id)
        {
            var data = await profCategoryService.GetByIdAsync(id);
            return data != null ? Ok(data) : NotFound(data);
        }

        [HttpPost("add")]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> Add(CreateProfessionalCategory license)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var result = await profCategoryService.AddAsync(license);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPut("update")]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(UpdateProfessionalCategory license)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var result = await profCategoryService.UpdateAsync(license);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpDelete("delete/{id}")]
        // [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delte(Guid id)
        {
            var result = await profCategoryService.DeleteAsync(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }
    }
}
