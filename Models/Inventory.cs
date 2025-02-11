namespace COMP2139_Assignment1.Models;

public class Inventory
{
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public int Price { get; set; }
    private int Quantity { get; set; }
    public bool LowStockAlert { get; set; }
    
}