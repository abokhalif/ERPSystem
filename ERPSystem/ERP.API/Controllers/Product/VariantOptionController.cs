using ERP.Application.DTOs.Product;
using ERP.Application.Implementation.GenericService;
using ERP.Application.Interfaces.IGenericServices;
using ERP.Application.Interfaces.IServices;
using ERP.Domain.Entities.Product;
using Microsoft.AspNetCore.Mvc;

namespace ERP.API.Controllers.Product
{
    public class VariantOptionCntroller : BaseApiController
    {
        private readonly IVariantOptionService _service;

        public VariantOptionCntroller(IVariantOptionService variantOptionService)
        {
            _service = variantOptionService;
        }
        [HttpGet("VariantOption{id}")]
        public async Task<IActionResult> GetVariantOptionById(int id)
        {
            var response = await _service.GetByIdAsync(id);
            return StatusCode(response.StatusCode, response);
        }
        [HttpGet("VariantOptions")]
        public async Task<IActionResult> GetAllVariantOption()
        {
            var response = await _service.GetAllAsync();
            return StatusCode(response.StatusCode, response);
        }
        [HttpPost("VariantOption")]
        public async Task<IActionResult> CreateVariantOption([FromBody] CreateVariantOptionDto dto)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var variantOption=new VariantOptions {Name=dto.Name };
            var response = await _service.CreateAsync(variantOption);
            return StatusCode(response.StatusCode, response);
        }
        [HttpPut("VariantOption{id}")]
        public async Task<IActionResult> UpdateVariantOption(int id, [FromBody] CreateVariantOptionDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var getResponse = await _service.GetByIdAsync(id);
            if (!getResponse.Success)
                return StatusCode(getResponse.StatusCode, getResponse);
            getResponse.Data.Name = dto.Name;
            var response = await _service.UpdateAsync(getResponse.Data);
            return StatusCode(response.StatusCode, response);
        }
        [HttpDelete("VariantOption{id}")]
        public async Task<IActionResult> DeleteVariantOption(int id)
        {
            var response = await _service.DeleteAsync(id);
            return StatusCode(response.StatusCode, response);
        }


    }
}
