
using COMP2139_Assignment1.Models;
using COMP2139_Assignment1.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace COMP2139_Assignment1.Controllers;

public class InventoryController : Controller
{
    // Hold instance of inventory class
    private readonly InventoryDbContext _context;
    
    public InventoryController(InventoryDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var inventory = _context.Products.ToList();
        return View(inventory);
    }

    [HttpGet]
    public IActionResult ViewInventory()
    {
        var products = _context.Products.ToList();
        return View(products);
    }

    public IActionResult Details(int id)
    {
        var product = _context.Products.FirstOrDefault(p => p.ProductId == id);
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
            // Add and Save product to Inventory DB
            _context.Products.Add(product);
            _context.SaveChanges();
            return RedirectToAction("ViewInventory");
        }
        
        // If state not valid, stay on product
        return View(product);
    }
}