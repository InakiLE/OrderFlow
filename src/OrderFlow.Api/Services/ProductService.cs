using OrderFlow.Api.Data;
using OrderFlow.Api.DTOs;
using OrderFlow.Api.Models;

namespace OrderFlow.Api.Services;

public class ProductService : IProductService
{
	private readonly AppDbContext _context;

	public ProductService(AppDbContext context)
	{
		_context = context;
	}

	public async Task<Product?> GetProduct(int id)
	{
		return await _context.Products.FindAsync(id);
	}

	public async Task<Product> CreateProduct(CreateProductDto dto)
	{
		var product = new Product
		{
			Name = dto.Name,
			Price = dto.Price
		};

		_context.Products.Add(product);
		await _context.SaveChangesAsync();

		return product;
	}

	public async Task<Product?> UpdateProduct(int productId, UpdateProductDto dto)
	{
		var product = await _context.Products.FindAsync(productId);

		if (product is null)
		{
			return null;
		}

		product.Name = dto.Name;
		product.Price = dto.Price;
		await _context.SaveChangesAsync();

		return product;
	}

	public async Task<bool> DeleteProduct(int id)
	{
		var product = await _context.Products.FindAsync(id);

		if (product is null)
		{
			return false;
		}

		_context.Products.Remove(product);
		await _context.SaveChangesAsync();

		return true;
	}
}
