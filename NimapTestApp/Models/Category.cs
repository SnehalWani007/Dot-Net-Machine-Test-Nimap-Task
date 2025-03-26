using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace NimapTestApp.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        [Required]
        public string? CategoryName { get; set; }
        public List<Product> Products { get; set; } = new List<Product>();
    }
}
