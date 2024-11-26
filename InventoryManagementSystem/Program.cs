using InventoryManagementSystem.Data;
using InventoryManagementSystem.Interfaces;

public class Program
{
    private static void Main(string[] args)
    {
        Product product = new Product("Samsung S24 Ultra", 2000, "Electronics", DateTime.Now.AddMonths(1));
        product.SetCategory("Smartphones");

        Console.WriteLine(product.GetItemDetails());
        product.ItemDescription();

        Console.WriteLine($"Category Name: {product.GetCategory()}");
        Console.WriteLine($"Total: {product.CalculateValue()}");
        if (product.IsPerishable())
        {
            product.HandleExpiration();
        }

        product.SetPrice(2400);
        Console.WriteLine($"New Price: {product.GetPrice()}");

        InventoryItem inventoryItem = new InventoryItem(0001, "Samsung S24 Ultra", 2000, "Electronics", DateTime.Now.AddMonths(1), 20);

        Console.WriteLine(inventoryItem.GetItemDetails());

        inventoryItem.AdjustQuantity(-5);

        Console.WriteLine($"Updated ===> {inventoryItem.GetItemDetails()}");

        inventoryItem.SetQuantity(100);

        Console.WriteLine($"New quantity: {inventoryItem.GetQuantity()}");


        var electronics = new ElectronicsItem(0002, "Iphone 14 Pro Max", 2200, "Electronics", DateTime.Now.AddYears(2), 10, 24);
        Console.WriteLine(electronics.GetItemDetails());
        Console.WriteLine($"Value: {electronics.CalculateValue():C}");

        var grocery = new GroceryItem(0003, "Coca-cola", 2.50, "Grocery", DateTime.Now.AddDays(3), 3, true);
        Console.WriteLine(grocery.GetItemDetails());
        Console.WriteLine($"Value: {grocery.CalculateValue():C}");

        var fragile = new FragileItem(0004, "Table", 120, "Fragile", DateTime.Now.AddMonths(3), 13, 50);
        Console.WriteLine(fragile.GetItemDetails());
        Console.WriteLine($"Value: {fragile.CalculateValue():C})");
    }
}