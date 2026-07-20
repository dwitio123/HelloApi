using HelloApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace HelloApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    [HttpGet("{id}")]
    public Product Get(int id)
    {
        return new Product
        {
            Id = id,
            Name = "Keyboard",
            Price = 350000
        };
    }

    [HttpGet("all")]
    public List<Product> GetAll()
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

    [HttpPost]
    public Product Create(Product product)
    {
        return product;
    }

    [HttpPut("{id}")]
    public string Update(int id)
    {        
        return $"Product {id} updated.";
    }

    [HttpDelete("{id}")]
    public string Delete(int id)
    {
        return $"Product {id} deleted.";
    }
}   