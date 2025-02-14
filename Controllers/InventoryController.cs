
using COMP2139_Assignment1.Models;
using COMP2139_Assignment1.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace COMP2139_Assignment1.Controllers;

public class InventoryController : Controller
{
    // ReadOnly file to hold instance of the database context
    private readonly InventoryDbContext _context;
    
    // Pass DB context to controller
    public InventoryController(InventoryDbContext context)
    {
        _context = context;
    }

    // Default action to retrieve all products
    public IActionResult Index()
    {
        // Create + show list of all products in inventory
        var inventory = _context.Products.ToList();
        return View(inventory);
    }

    // GET Method to display inventory
    [HttpGet]
    public IActionResult ViewInventory()
    {
        // Get + show all products from inventory 
        var products = _context.Products.ToList();
        return View(products);
    }

    // Method to output product details by id
    public IActionResult Details(int id)
    {
        // Retreive product details by id from the Database
        var product = _context.Products.FirstOrDefault(p => p.ProductId == id);
        
        // Handle error: no product found
        if (product == null)
        {
            return NotFound();
        }
        // Pass the product details to the view
        return View(product);
    }


    // GET Method to display the AddProduct form
    [HttpGet]
    public IActionResult AddProduct()
    {
        // Only returns the AddProduct view
        return View(); 
    }
    
    // POST Method to handle AddProduct form
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult AddProduct(Product product)
    {
        // Verify product model
        if (ModelState.IsValid)
        {
            // Add and Save product to inventory
            _context.Products.Add(product);
            _context.SaveChanges();
            
            // Redirect Back to ViewInventory action
            return RedirectToAction("ViewInventory");
        }
        
        // Handle error: model state is not valid
        return View(product);
    }
}