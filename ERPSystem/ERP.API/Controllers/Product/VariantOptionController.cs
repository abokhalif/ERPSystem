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
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateVariantOptionDto dto)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var variantOption=new VariantOptions {Name=dto.Name };
            var response = await _service.CreateAsync(variantOption);
            return StatusCode(response.StatusCode, response);
        }
    }
}
