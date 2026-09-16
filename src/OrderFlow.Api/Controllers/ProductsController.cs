using Microsoft.AspNetCore.Mvc;
using OrderFlow.Api.DTOs;
using OrderFlow.Api.Services;

namespace OrderFlow.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
	private readonly IProductService _productService;

	public ProductsController(IProductService productService)
	{
		_productService = productService;
	}

	[HttpGet("{id}")]
	public async Task<IActionResult> GetProduct(int id)
	{
		var product = await _productService.GetProduct(id);
		return product is null ? NotFound() : Ok(product);
	}

	[HttpPost]
	public async Task<IActionResult> CreateProduct(CreateProductDto dto)
	{
		var product = await _productService.CreateProduct(dto);
		return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
	}

	[HttpPut("{id}")]
	public async Task<IActionResult> UpdateProduct(int id, UpdateProductDto dto)
	{
		var product = await _productService.UpdateProduct(id, dto);
		return product is null ? NotFound() : Ok(product);
	}

	[HttpDelete("{id}")]
	public async Task<IActionResult> DeleteProduct(int id)
	{
		var deleted = await _productService.DeleteProduct(id);
		return deleted ? NoContent() : NotFound();
	}
}
