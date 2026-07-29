using HelloApi.Models;
using HelloApi.Repositories;

namespace HelloApi.Services;

public class ProductService
{
    private readonly IProductRepository _repository;

    public ProductService(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<Product>> GetAllProductAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<Product?> GetProductAsync(int id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task<Product> CreateProductAsync(string name, decimal price)
    {
        var product = await _repository.GetAllAsync();
        var newProduct = new Product
        {
            // Id = product.Any() ? product.Max(p => p.Id) + 1 : 1,
            Name = name,
            Price = price
        };

        await _repository.AddAsync(newProduct);
        
        return newProduct;
    }
}