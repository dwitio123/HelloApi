using HelloApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace HelloApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
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
    public ActionResult<Product> Create(Product product)
    {
        return CreatedAtAction(
            nameof(GetById),
            new { id = product.Id },
            product
        );
    }

    [HttpPut("{id}")]
    public string Update(int id)
    {        
        return $"Product {id} updated.";
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