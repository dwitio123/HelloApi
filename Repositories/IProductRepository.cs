using HelloApi.Models;

namespace HelloApi.Repositories;

public interface IProductRepository
{
    Task<List<Product>> GetAllAsync();
    Task<Product?> GetByIdAsync(int id);
    Task AddAsync(Product product);
    void Update(Product product);
    void Delete(Product product);
    Task<List<Product>> GetExpensiveProductsAsync(decimal minimumPrice);
    Task<List<Product>> SearchByNameAsync(string keyword);
    Task<List<Product>> GetPagedAsync(int page, int pageSize);
    Task<List<Product>> SearchAsync(string keyword, int page, int pageSize);
}