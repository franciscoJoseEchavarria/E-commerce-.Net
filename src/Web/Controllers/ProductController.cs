using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NuevoProyecto.API.src.Core.Interfaces;
using NuevoProyecto.API.src.Application.DTOs;

namespace NuevoProyecto.API.src.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        
         private readonly IProductService _productService;

         public ProductController(IProductService productService)
         {
             _productService = productService;
         }

        [HttpGet]
         public async Task<ActionResult<IEnumerable<ProductDto>>> GetAll()
        {
            var products = await _productService.GetAllAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetById(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            if (product == null)
                return NotFound();
            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<ProductDto>> Add([FromBody] ProductCreateDto productCreateDto)
        {
            if (productCreateDto == null)
                return BadRequest();

            var createdProduct = await _productService.AddAsync(productCreateDto);
            return CreatedAtAction(nameof(GetById), new { id = createdProduct.Id }, createdProduct);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ProductDto productDto)
        {
            if (id != productDto.Id)
                return BadRequest();

            await _productService.UpdateAsync(id, productDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            if (product == null)
                return NotFound();

            await _productService.DeleteAsync(id);
            return NoContent();
        }
    }
}