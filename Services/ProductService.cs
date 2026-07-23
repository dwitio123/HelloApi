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

    public List<Product> GetAllProduct()
    {
        return _repository.GetAll();
    }

    public Product? GetProduct(int id)
    {
        return _repository.GetById(id);
    }

    public Product CreateProduct(string name, decimal price)
    {
        var product = _repository.GetAll();
        var newProduct = new Product
        {
            Id = product.Max(p => p.Id) + 1,
            Name = name,
            Price = price
        };

        _repository.Add(newProduct);
        
        return newProduct;
    }
}