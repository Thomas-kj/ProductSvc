using Microsoft.AspNetCore.Mvc;
using ProductService.API.Models.DTOs;
using ProductService.API.Services.Interfaces;

namespace ProductService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        [Route("product_shortlist")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> GetAllProducts()
        {
            var products = await _productService.GetAllAsync();
            if (products == null)
                return NoContent();
            return Ok(products);
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> GetProductById(int id)
        {
            if (id <= 0)
                return BadRequest($"Invalid Product Id {id}");
            
            var product = await _productService.GetByIdAsync(id);
            if (product == null)
                return NotFound($"Product with Id {id} not found.");
            
            return Ok(product);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> AddProduct([FromBody] ProductDto productDto)
        {
            try
            {
                var createdProduct = await _productService.AddProductAsync(productDto);
                if (createdProduct == null)
                    return BadRequest("Product not Created.");
                return CreatedAtAction(nameof(GetProductById), new { id = createdProduct.Id }, createdProduct);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> UpdateProduct(int id, [FromBody] ProductDto productDto)
        {
            if (id <= 0)
                return BadRequest($"Invalid Product Id {id}");
            try
            {
                var updatedProduct = await _productService.UpdateAsync(id, productDto);
                if (updatedProduct == null)
                    return NotFound($"Product with Id {id} not found.");

                return Ok(updatedProduct);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            if(id <= 0)
                return BadRequest($"Invalid Product Id {id}");
            
            var isDeleted = await _productService.DeleteAsync(id);
            return isDeleted ? NoContent() : NotFound($"Product with Id {id} not found.");
        }
    }
}
