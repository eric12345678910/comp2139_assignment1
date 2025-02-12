namespace COMP2139_Assignment1.Models;

public class Inventory
{
    // ---------------------------------------------    Attributes
    private List<Product> _products = new List<Product>();

    public List<Product> Products => _products;
    
    // ---------------------------------------------    Methods
    
    // Add product to inventory
    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    // Get all products from inventory
    public List<Product> GetProducts()
    {
        return _products;
    }

}