using COMP2139_Assignment1.Models;
using Microsoft.AspNetCore.Mvc;

namespace COMP2139_Assignment1.Controllers;

public class InventoryController : Controller
{

    public readonly Inventory _inventory;

    public InventoryController(Inventory inventory)
    {
        _inventory = inventory;
    }
    
    // Display Add Product Form
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
 
        _inventory.AddProduct(product);

        return RedirectToAction("Inventory");
    }
    
}