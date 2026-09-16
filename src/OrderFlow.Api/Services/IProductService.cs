using OrderFlow.Api.DTOs;
using OrderFlow.Api.Models;

namespace OrderFlow.Api.Services;

public interface IProductService
{
	Task<Product?> GetProduct(int productId);

	Task<Product> CreateProduct(CreateProductDto dto);

	Task<Product?> UpdateProduct(int productId,UpdateProductDto dto);

	Task<bool> DeleteProduct(int productId);
}