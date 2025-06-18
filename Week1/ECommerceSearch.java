
    
import java.util.*;

public class ECommerceSearch {
    public static void main(String[] args) {
        // Product class
        class Product {
            int productId;
            String productName;
            String category;

            public Product(int productId, String productName, String category) {
                this.productId = productId;
                this.productName = productName;
                this.category = category;
            }

            @Override
            public String toString() {
                return "Product ID: " + productId + ", Name: " + productName + ", Category: " + category;
            }
        }

        // Sample products
        Product[] products = {
            new Product(101, "Shoes", "Footwear"),
            new Product(102, "T-shirt", "Clothing"),
            new Product(103, "Laptop", "Electronics"),
            new Product(104, "Watch", "Accessories"),
            new Product(105, "Bag", "Travel")
        };

        String searchName = "Laptop";

        // Linear Search
        Product linearResult = null;
        for (Product product : products) {
            if (product.productName.equalsIgnoreCase(searchName)) {
                linearResult = product;
                break;
            }
        }

        System.out.println("Linear Search Result:");
        if (linearResult != null)
            System.out.println(linearResult);
        else
            System.out.println("Product not found.");

        // Binary Search (sort first by product name)
        Arrays.sort(products, Comparator.comparing(p -> p.productName.toLowerCase()));

        int left = 0, right = products.length - 1;
        Product binaryResult = null;

        while (left <= right) {
            int mid = (left + right) / 2;
            int cmp = products[mid].productName.compareToIgnoreCase(searchName);

            if (cmp == 0) {
                binaryResult = products[mid];
                break;
            } else if (cmp < 0) {
                left = mid + 1;
            } else {
                right = mid - 1;
            }
        }

        System.out.println("\nBinary Search Result:");
        if (binaryResult != null)
            System.out.println(binaryResult);
        else
            System.out.println("Product not found.");

        // Time complexity comparison comment
        System.out.println("\nAnalysis:");
        System.out.println("Linear Search: O(n)");
        System.out.println("Binary Search: O(log n), but requires sorted data.");
    }

}