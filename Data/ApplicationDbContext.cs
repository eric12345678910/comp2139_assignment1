using COMP2139_Assignment1.Models;
using Microsoft.EntityFrameworkCore;

namespace COMP2139_Assignment1.Data;

public class InventoryDbContext : DbContext
{
    public InventoryDbContext(DbContextOptions<InventoryDbContext> options) : base(options) { }
    
    public DbSet<Product> Products { get; set; }
    
}