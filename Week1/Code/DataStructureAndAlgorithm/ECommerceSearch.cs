using System;
using System.Linq;

public class ECommerceSearch
{
    // Product class
    class Product
    {
        public int ProductId;
        public string ProductName;
        public string Category;

        public Product(int productId, string productName, string category)
        {
            ProductId = productId;
            ProductName = productName;
            Category = category;
        }

        public override string ToString()
        {
            return $"Product ID: {ProductId}, Name: {ProductName}, Category: {Category}";
        }
    }

    public static void Main(string[] args)
    {
        // Sample products
        Product[] products = {
            new Product(101, "Shoes", "Footwear"),
            new Product(102, "T-shirt", "Clothing"),
            new Product(103, "Laptop", "Electronics"),
            new Product(104, "Watch", "Accessories"),
            new Product(105, "Bag", "Travel")
        };

        string searchName = "Laptop";

        // Linear Search
        Product linearResult = null;
        foreach (var product in products)
        {
            if (product.ProductName.Equals(searchName, StringComparison.OrdinalIgnoreCase))
            {
                linearResult = product;
                break;
            }
        }

        Console.WriteLine("Linear Search Result:");
        if (linearResult != null)
            Console.WriteLine(linearResult);
        else
            Console.WriteLine("Product not found.");

        // Binary Search (sort first by product name)
        var sortedProducts = products.OrderBy(p => p.ProductName.ToLower()).ToArray();

        int left = 0, right = sortedProducts.Length - 1;
        Product binaryResult = null;

        while (left <= right)
        {
            int mid = (left + right) / 2;
            int cmp = string.Compare(sortedProducts[mid].ProductName, searchName, StringComparison.OrdinalIgnoreCase);

            if (cmp == 0)
            {
                binaryResult = sortedProducts[mid];
                break;
            }
            else if (cmp < 0)
            {
                left = mid + 1;
            }
            else
            {
                right = mid - 1;
            }
        }

        Console.WriteLine("\nBinary Search Result:");
        if (binaryResult != null)
            Console.WriteLine(binaryResult);
        else
            Console.WriteLine("Product not found.");

        
        Console.WriteLine("\nAnalysis:");
        Console.WriteLine("Linear Search: O(n)");
        Console.WriteLine("Binary Search: O(log n), but requires sorted data.");
    }
}
