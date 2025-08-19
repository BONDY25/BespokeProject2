using System;
using System.Collections.Generic;

class Program
{
    static List<Product> products = new List<Product>();

    static async void MainMenu()
    {
        Console.Clear();
        Console.WriteLine("----------------------------------------------------------------------------------------------------------------");
        Console.WriteLine("--- BOND'S GOODS ---");
        Console.WriteLine("----------------------------------------------------------------------------------------------------------------");
        Console.WriteLine("Hello, Welcome to my store.");
        Console.WriteLine("----------------------------------------------------------------------------------------------------------------");
        Console.WriteLine("Service Menu");
        Console.WriteLine("----------------------------------------------------------------------------------------------------------------");
        Console.WriteLine("1. Browse Product(s)");
        Console.WriteLine("2. Sell Product(s)");
        Console.WriteLine("3. Return Product(s)");
        Console.WriteLine("4. Exit");
        Console.WriteLine("----------------------------------------------------------------------------------------------------------------");
        Console.WriteLine("Please Choose a Service");
        string menuInput = Console.ReadLine();
        if (menuInput == "1")
        {
            BrowseProducts();
        }
        else if (menuInput == "2")
        {
            SellProducts();
        }
        else if (menuInput == "3")
        {
            ReturnProducts();
        }
        else if (menuInput == "4")
        {
            Environment.Exit(0);
        }
        else
        {
            Console.WriteLine("Menu input not valid. Press any key to try again.");
            Console.ReadKey();
            MainMenu();
        }
    }

    static void BrowseProducts()
    {
        Console.Clear();
        Console.WriteLine("----------------------------------------------------------------------------------------------------------------");
        Console.WriteLine("--- BOND'S GOODS ---");
        Console.WriteLine("----------------------------------------------------------------------------------------------------------------");
        Console.WriteLine("For Sale:");
        Console.WriteLine("SKU......Name.....................Price");
        Console.WriteLine("----------------------------------------------------------------------------------------------------------------");

        foreach (var product in products)
        {
            Console.WriteLine($"{product.SKU}......{product.Name}....................................{product.Price}");
        }

        Console.WriteLine("----------------------------------------------------------------------------------------------------------------");
        Console.WriteLine("1. Purchase Product");
        Console.WriteLine("2. Return to Main Menu");
        Console.WriteLine("----------------------------------------------------------------------------------------------------------------");
        Console.WriteLine("Choose an option:");

        string purchaseOption = Console.ReadLine();

        if (purchaseOption == "1")
        {
            PurchaseProduct();
        }
        else if (purchaseOption == "2")
        {
            MainMenu();
        }
        else
        {
            Console.WriteLine("Invalid option. Press any key to try again.");
            Console.ReadKey();
            BrowseProducts();
        }
    }

    static void PurchaseProduct()
    {
        Console.Write("Enter the SKU to purchase: ");
        string skuToPurchase = Console.ReadLine();

        // Find the product with the given SKU in the list
        var productToPurchase = products.Find(p => p.SKU == skuToPurchase);

        if (productToPurchase != null)
        {
            // Remove the purchased product from the list
            products.Remove(productToPurchase);

            Console.WriteLine($"Product '{productToPurchase.Name}' with SKU '{productToPurchase.SKU}' purchased successfully!");
        }
        else
        {
            Console.WriteLine($"Product with SKU '{skuToPurchase}' not found.");
        }

        Console.WriteLine("Press any key to return to the main menu...");
        Console.ReadKey();
        MainMenu();
    }


    static void SellProducts()
    {
        Console.Clear();
        Console.WriteLine("----------------------------------------------------------------------------------------------------------------");
        Console.WriteLine("--- BOND'S GOODS ---");
        Console.WriteLine("----------------------------------------------------------------------------------------------------------------");
        Console.WriteLine("Sell Product(s)");
        Console.WriteLine("----------------------------------------------------------------------------------------------------------------");

        Console.Write("Enter SKU: ");
        string sku = Console.ReadLine();

        Console.Write("Enter Product Name: ");
        string name = Console.ReadLine();

        Console.Write("Enter Price: ");
        decimal price;
        while (!decimal.TryParse(Console.ReadLine(), out price))
        {
            Console.WriteLine("Invalid price. Please enter a valid numeric value.");
            Console.Write("Enter Price: ");
        }

        // Add the new product to the list
        products.Add(new Product { SKU = sku, Name = name, Price = price });

        Console.WriteLine("Product sold successfully!");

        Console.WriteLine("Press any key to return to the main menu...");
        Console.ReadKey();
        MainMenu();
    }


    static void ReturnProducts()
    {
        // Implement the logic for returning products here
        Console.WriteLine("----------------------------------------------------------------------------------------------------------------");
        Console.WriteLine("--- BOND'S GOODS ---");
        Console.WriteLine("----------------------------------------------------------------------------------------------------------------");
        Console.WriteLine("Return Product(s) functionality not implemented yet.");
        Console.WriteLine("----------------------------------------------------------------------------------------------------------------");
        Console.WriteLine("Press any key to return to the main menu...");
        Console.ReadKey();
        MainMenu();
    }

    class Product
    {
        public string SKU { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }

    static void Main()
    {
        // You can add some sample products for testing
        products.Add(new Product { SKU = "001", Name = "Apple", Price = 19.99m });
        products.Add(new Product { SKU = "002", Name = "Bread", Price = 29.99m });
        products.Add(new Product { SKU = "003", Name = "Orange", Price = 50.00m });
        products.Add(new Product { SKU = "004", Name = "Cheese", Price = 4.50m });
        products.Add(new Product { SKU = "005", Name = "Crackers", Price = 8.99m });
        products.Add(new Product { SKU = "006", Name = "Venetor Class Star Destroyer", Price = 50000000000.99m });

        MainMenu();
    }
}
