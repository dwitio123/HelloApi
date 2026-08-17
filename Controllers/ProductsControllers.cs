using HelloApi.DTOs;
using HelloApi.Models;
using HelloApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HelloApi.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class ProductsController : ControllerBase
{
    private readonly ProductService _productService;

    public ProductsController(ProductService productService)
    {
        _productService = productService;
    }

    // [HttpGet]
    // public ActionResult<Product> Get()
    // {
    //     var product = _productService.GetProduct();
    //     return Ok(new ProductDto
    //     {
    //         Id = product.Id,
    //         Name = product.Name,
    //         Price = product.Price
    //     });
    // }

    [HttpGet("{id}")]
    public async Task<ActionResult<ProductDto>> GetById(int id)
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
    public async Task<ActionResult<List<ProductDto>>> GetAll()
    {
        var product = await _productService.GetAllProductAsync();
        var productDtos = product.Select(product => new ProductDto
        {
            Id = product.Id,
            Name = product.Name,
            Price = product.Price
        }).ToList();
        
        return Ok(productDtos);
    }

    [HttpPost]
    public async Task<ActionResult<ProductDto>> Create(CreateProductDto request)
    {
        var product = await _productService.CreateProductAsync(request.Name, request.Price, request.Description, request.CategoryId);

        var productDto = new ProductDto
        {
            Id = product.Id,
            Name = product.Name,
            Price = product.Price,
            Description = product.Description,
            CategoryId = product.CategoryId
        };

        return CreatedAtAction(
            nameof(GetById),
            new { id = productDto.Id },
            productDto
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

    [Authorize(Roles = "Admin")]
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

    [HttpGet("expensive")]
    public async Task<ActionResult<List<ProductDto>>> GetExpensiveProducts(decimal minimumPrice)
    {
        var products = await _productService.GetExpensiveProductsAsync(minimumPrice);
        var dto = products.Select(products => new ProductDto
        {
            Id = products.Id,
            Name = products.Name,
            Price = products.Price,
            CategoryId = products.CategoryId
        }).ToList();

        return Ok(dto);
    }

    [HttpGet("search")]
    public async Task<ActionResult<List<ProductDto>>> Search(string keyword)
    {
        var products = await _productService.SearchByNameAsync(keyword);
        var dto = products.Select(products => new ProductDto
        {
            Id = products.Id,
            Name = products.Name,
            Price = products.Price,
            Description = products.Description
        }).ToList();

        return Ok(dto);
    }

    [HttpGet]
    public async Task<ActionResult<List<ProductDto>>> GetAll(
        int page = 1,
        int pageSize = 10)
    {
        var products = await _productService.GetPagedProductsAsync(page, pageSize);
        var dto = products.Select(product => new ProductDto
        {
            Id = product.Id,
            Name = product.Name,
            Price = product.Price,
            CategoryId = product.CategoryId
        }).ToList();

        return Ok(dto);
    }

    [HttpGet("search-paged")]
    public async Task<ActionResult<List<ProductDto>>> SearchPaged(
        string keyword,
        int page = 1,
        int pageSize = 10)
    {
        var products = await _productService.SearchProductsAsync(keyword, page, pageSize);
        var dto = products.Select(product => new ProductDto
        {
            Id = product.Id,
            Name = product.Name,
            Price = product.Price,
            CategoryId = product.CategoryId
        }).ToList();

        return Ok(dto);
    }

    [AllowAnonymous]
    [HttpGet("public")]
    public IActionResult PublicInfo()
    {
        return Ok("Semua orang bisa mengakses.");
    }
}   