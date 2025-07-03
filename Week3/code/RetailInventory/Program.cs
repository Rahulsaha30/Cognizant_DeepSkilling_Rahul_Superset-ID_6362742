using Model;
using Microsoft.EntityFrameworkCore;

class Program
{
  static async Task Main(string[] args)
  {
    using var context = new AppDbContext();
    await context.Database.EnsureCreatedAsync();


    var electronics = new Category { Name = "Electronics" };
    var groceries = new Category { Name = "Groceries" };


    await context.categories.AddRangeAsync(electronics, groceries);


    var laptop = new Product
    {
      Name = "Laptop",
      Price = 75000,
      Category = electronics
    };

    var rice = new Product
    {
      Name = "Rice Bag",
      Price = 1200,
      Category = groceries
    };


    await context.products.AddRangeAsync(laptop, rice);


    await context.SaveChangesAsync();

    Console.WriteLine("inserted successfully.");

  // Retrieving
        
         var allProducts = await context.products
            .Include(p => p.Category)
            .ToListAsync();

        Console.WriteLine("All Products:");
        foreach (var p in allProducts)
        {
            Console.WriteLine($"- {p.Name} | ₹{p.Price} | Category: {p.Category.Name}");
        }

      
        var productById = await context.products.FindAsync(1);
        if (productById != null)
        {
            Console.WriteLine($"\n🔍 Product with ID = 1: {productById.Name} | ₹{productById.Price}");
        }

       
        var expensive = await context.products.FirstOrDefaultAsync(p => p.Price > 50000);
        if (expensive != null)
        {
            Console.WriteLine($"\n💰 Expensive Product: {expensive.Name} | ₹{expensive.Price}");
        }
    }
}
