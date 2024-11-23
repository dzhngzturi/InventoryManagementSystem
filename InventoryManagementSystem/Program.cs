using InventoryManagementSystem.Data;
using InventoryManagementSystem.Interfaces;

public class Program
{
    private static void Main(string[] args)
    {
        IItem item = new Item("Lenovo",1000,2);
        IItem item2 = new Item("Samsung 24 Ultra",2200,3);

        Console.WriteLine(item.GetItemDetails());
        item.ItemDescription();
        Console.WriteLine(($"Total: {item.CalculateValue()}"));


        Console.WriteLine(item2.GetItemDetails());
        item2.ItemDescription();
        Console.WriteLine($"Total: {item2.CalculateValue()}");
    }
}