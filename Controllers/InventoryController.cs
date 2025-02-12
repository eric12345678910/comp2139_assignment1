
using COMP2139_Assignment1.Models;
using Microsoft.AspNetCore.Mvc;

namespace COMP2139_Assignment1.Controllers;

public class InventoryController : Controller
{
    // Hold instance of inventory class
    private readonly Inventory _inventory;
    
    public InventoryController(Inventory inventory)
    {
        _inventory = inventory;
    }

    public IActionResult ViewInventory()
    {
        return View();
    }
    
    // Display Add Product Form
    [HttpGet]
    public IActionResult Index()
    {
        // Retreive all products from inventory
        var products = _inventory.GetProducts();
        return View(products);
    }
    
    [HttpGet]
    public IActionResult AddProduct()
    {
        return View(); // fwd to AddProduct view
    }

    // Handle form submission
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult AddProduct(Product product)
    {
        // Add product to inventory
        _inventory.AddProduct(product);

        // Redirect to Inventory
        return RedirectToAction("Inventory");
    }


    
}