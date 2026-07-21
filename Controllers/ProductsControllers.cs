using HelloApi.DTOs;
using HelloApi.Models;
using HelloApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace HelloApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly ProductService _productService;

    public ProductsController(ProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public ActionResult<Product> Get()
    {
        var product = _productService.GetProduct();
        return Ok(new ProductDto
        {
            Id = product.Id,
            Name = product.Name,
            Price = product.Price
        });
    }

    [HttpGet("{id}")]
    public ActionResult<Product> GetById(int id)
    {
        if (id <= 0)
        {
            return BadRequest("Id harus lebih dari 0.");
        }

        if (id != 1)
        {
            return NotFound();
        }

        return Ok(new Product
        {
            Id = 1,
            Name = "Keyboard",
            Price = 350000
        });
    }

    [HttpGet("all")]
    public ActionResult<List<ProductDto>> GetAll()
    {
        var product = _productService.GetAllProduct();
        var productDtos = product.Select(product => new ProductDto
        {
            Id = product.Id,
            Name = product.Name,
            Price = product.Price
        }).ToList();
        
        return Ok(productDtos);
    }

    [HttpPost]
    public ActionResult<ProductDto> Create(CreateProductDto request)
    {
        var product = new Product
        {
            Id = 1,
            Name = request.Name,
            Price = request.Price,
            CreatedAt = DateTime.Now,
            IsDeleted = false
        };

        var dto = new ProductDto
        {
            Id = product.Id,
            Name = product.Name,
            Price = product.Price
        };

        return CreatedAtAction(
            nameof(GetById),
            new { id = product.Id },
            dto
        );
    }

    [HttpPut("{id}")]
    public ActionResult<ProductDto> Update(int id, UpdateProductDto request)
    {        
        var product = new Product
        {
            Id = id,
            Name = request.Name,
            Price = request.Price,
            CreatedAt = DateTime.Now,
            IsDeleted = false
        };

        var dto = new ProductDto
        {
            Id = product.Id,
            Name = product.Name,
            Price = product.Price
        };

        return Ok(dto);
    }

    [HttpDelete("{id}")]
    public ActionResult Delete (int id)
    {
        if (id <= 0)
        {
            return BadRequest();
        }
        
        if (id == 999)
        {
            return NotFound();
        }

        return NoContent();
    }
}   