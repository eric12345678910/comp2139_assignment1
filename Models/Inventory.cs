namespace COMP2139_Assignment1.Models;

public class Inventory
{
    // Attributes
    private List<Product> _products = new List<Product>();

    // Methods
    // Add product to inventory
    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

}