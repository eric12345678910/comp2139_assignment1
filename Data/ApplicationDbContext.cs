using COMP2139_Assignment1.Models;
using Microsoft.EntityFrameworkCore;

namespace COMP2139_Assignment1.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }

    public DbSet<Inventory> Inventories
    {
        get;
        set;
    }


}