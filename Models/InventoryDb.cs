using COMP2139_Assignment1.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace COMP2139_Assignment1.Models;

public class InventoryDb
{

    private readonly InventoryDbContext _inventory;

    public InventoryDb(InventoryDbContext inventory)
    {
        _inventory = inventory;
    }


    public void AddProduct(Product product)
    {
        _inventory.Products.Add(product);
        _inventory.SaveChanges();
    }

    public List<Product> GetProducts()
    {
        return _inventory.Products.ToList();
    }

}