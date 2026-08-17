using HelloApi.Models;

public interface IProductService
{
    Task<List<Product>> GetAllAsync();
    Task<Product?> GetByIdAsync(int id);
    Task<List<Product>> GetExpensiveProductsAsync(decimal minimumPrice);
}