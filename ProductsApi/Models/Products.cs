using System.ComponentModel.DataAnnotations.Schema;

namespace ProductsApi.Models
{
    [Table("products")]
    public class Product
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal Price { get; set; }
    }
}