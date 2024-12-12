using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace Cafeteria.Models;
    
    public class ProductCategoryViewModel
    {
        public string? ProductCategory { get; set; }
        public SelectList Categories { get; set; } = null!;
        public List<Product> Products { get; set; } = new List<Product>();
    }