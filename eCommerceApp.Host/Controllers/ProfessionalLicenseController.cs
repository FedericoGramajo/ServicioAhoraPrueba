using eCommerceApp.Application.DTOs.Category;
using eCommerceApp.Application.DTOs.ProfessionalLicense;
using eCommerceApp.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace eCommerceApp.Host.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ProfessionalLicenseController(IProfessionalLicenseService licenseService) : ControllerBase
    {
        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            var data = await licenseService.GetAllAsync();
            return data.Any() ? Ok(data) : NotFound(data);
        }

        [HttpGet("single/{id}")]
        public async Task<IActionResult> GetSingle(Guid id)
        {
            var data = await licenseService.GetByIdAsync(id);
            return data != null ? Ok(data) : NotFound(data);
        }

        [HttpPost("add")]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> Add(CreateProfessionalLicense license)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var result = await licenseService.AddAsync(license);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPut("update")]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(UpdateProfessionalLicense license)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var result = await licenseService.UpdateAsync(license);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpDelete("delete/{id}")]
        // [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delte(Guid id)
        {
            var result = await licenseService.DeleteAsync(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }
    }
}
