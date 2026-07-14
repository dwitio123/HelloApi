using HelloApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace HelloApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    [HttpGet]
    public Product Get()
    {
        return new Product
        {
            Id = 1,
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
}