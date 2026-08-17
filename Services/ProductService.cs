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

    public async Task<Product> CreateProductAsync(string name, decimal price, string description, int category_id)
    {
        var product = await _repository.GetAllAsync();
        var newProduct = new Product
        {
            // Id = product.Any() ? product.Max(p => p.Id) + 1 : 1,
            Name = name,
            Price = price,
            Description = description,
            CategoryId = category_id
        };

        await _repository.AddAsync(newProduct);
        
        return newProduct;
    }

    public async Task<List<Product>> GetExpensiveProductsAsync(decimal minimumPrice)
    {
        return await _repository.GetExpensiveProductsAsync(minimumPrice);
    }

    public Task<List<Product>> SearchByNameAsync(string keyword)
    {
        return _repository.SearchByNameAsync(keyword);
    }

    public async Task<List<Product>> GetPagedProductsAsync(int page, int pageSize)
    {
        return await _repository.GetPagedAsync(page, pageSize);
    }

    public async Task<List<Product>> SearchProductsAsync(string keyword, int page, int pageSize)
    {
        return await _repository.SearchAsync(keyword, page, pageSize);
    }
}