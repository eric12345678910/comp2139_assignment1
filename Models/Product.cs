using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;

namespace COMP2139_Assignment1.Models;

public class Product
{

    public int ProductId { get; set; }
    
    [Required]
    [StringLength(100)]
    public string ProductName { get; set; }
    
    [Column(TypeName = "decimal(18,2)")]
    public decimal Price { get; set; }

    [StringLength(100)]
    public string Category { get; set; }
    
    public int CategoryId { get; set; }

    public int Quantity { get; set; }
    
    
    public Product(){}
    
    public Product(string productName)
    {
        // Set non-nullable ProductName
        ProductName = productName ?? throw new ArgumentNullException(nameof(productName));
    }
}