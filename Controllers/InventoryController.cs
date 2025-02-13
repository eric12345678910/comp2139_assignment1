
using COMP2139_Assignment1.Models;
using COMP2139_Assignment1.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace COMP2139_Assignment1.Controllers;

public class InventoryController : Controller
{
    // Hold instance of inventory class
    private readonly InventoryDb _inventory;
    
    public InventoryController(InventoryDb inventory)
    {
        _inventory = inventory;
    }

    [HttpGet]
    public IActionResult ViewInventory()
    {
        var products = _inventory.GetProducts();
        return View(products);
    }

    public IActionResult Details(int id)
    {
        var product = _inventory.GetProducts().FirstOrDefault(p => p.ProductId == id);
        if (product == null)
        {
            return NotFound();
        }
        return View(product);
    }

    [HttpGet]
    public IActionResult AddProduct()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult AddProduct(Product product)
    {
        if (ModelState.IsValid)
        {
            _inventory.AddProduct(product);
            return RedirectToAction("ViewInventory");
        }
        
        return View(product);
    }
}