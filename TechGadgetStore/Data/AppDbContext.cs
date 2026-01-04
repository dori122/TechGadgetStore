using Microsoft.EntityFrameworkCore;
using TechGadgetStore.Models;

namespace TechGadgetStore.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<AdminUser> AdminUsers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configure table names to match your PostgreSQL database
        modelBuilder.Entity<Product>().ToTable("Products");
        modelBuilder.Entity<Category>().ToTable("Categories");
        modelBuilder.Entity<AdminUser>().ToTable("AdminUsers");

        // Configure relationships
        modelBuilder.Entity<Product>()
            .HasOne(p => p.Category)
            .WithMany(c => c.Products)
            .HasForeignKey(p => p.CategoryId);
    }
}