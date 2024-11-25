using InventoryManagementSystem.Data;
using InventoryManagementSystem.Interfaces;

public class Program
{
    private static void Main(string[] args)
    {
        Product product = new Product("Samsung S24 Ultra", 2000, 2, "Smartphones",DateTime.Now.AddMonths(1));
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
    }
}