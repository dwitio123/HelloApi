using HelloApi.Models;

namespace HelloApi.Services;

public class ProductService
{
    public Product GetProduct()
    {
        return new Product
        {
            Id = 1,
            Name = "Keyboard",
            Price = 350000  
        };
    }

    public List<Product> GetAllProduct()
    {
        return new List<Product>
        {
            new Product
            {
                Id = 1,
                Name = "Keyboard",
                Price = 350000
            },
            new Product
            {
                Id = 2,
                Name = "Mouse",
                Price = 150000
            },
        };
    }
}