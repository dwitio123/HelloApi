using HelloApi.Data;
using HelloApi.Models;

namespace HelloApi.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly AppDbContext _context;

    public ProductRepository(AppDbContext context)
    {
        _context = context;
    }

    private static readonly List<Product> _products = new()
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
            }
    };
    public List<Product> GetAll()
    {
        return _context.Products.ToList();
    }

    public Product? GetById(int id)
    {
        return _context.Products.FirstOrDefault(p => p.Id == id);
    }

    public void Add(Product product)
    {
        _context.Products.Add(product);
        _context.SaveChanges();
    }

    public void Update(Product product)
    {
        _context.Products.Update(product);
        _context.SaveChanges();
    }

    public void Delete(Product product)
    {
        _context.Products.Remove(product);
        _context.SaveChanges();
    }
}