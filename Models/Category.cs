namespace COMP2139_Assignment1.Models;

public class Category
{
    public int CategoryId { get; set; } // pk.
    public string CategoryName { get; set; }
    
    public ICollection<Product> Products { get; set; }
    
}