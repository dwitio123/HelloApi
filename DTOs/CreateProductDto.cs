using System.ComponentModel.DataAnnotations;

namespace HelloApi.DTOs;

public class CreateProductDto
{
    [Required(ErrorMessage = "Nama produk wajib diisi.")]
    [StringLength(100, MinimumLength = 3)]
    public string Name { get; set; } = "";

    [Range(1000, 100000000)]
    public decimal Price { get; set; }

    [Required(ErrorMessage = "Deskripsi produk wajib diisi.")]
    [StringLength(300, MinimumLength = 10)]
    public string Description { get; set; } = "";

    [Required(ErrorMessage = "Id kategori wajib diisi.")]
    public int CategoryId { get; set; }
}