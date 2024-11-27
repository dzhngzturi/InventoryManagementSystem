using InventoryManagementSystem.Data;
using InventoryManagementSystem.Interfaces;

public class Program
{
    private static void Main(string[] args)
    {
        InventoryManager manager = new InventoryManager();

        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("Inventory Management System");
            Console.WriteLine("1. Add item");
            Console.WriteLine("2. Remove item by ID");
            Console.WriteLine("3. Display items");
            Console.WriteLine("4. Categorize item");
            Console.WriteLine("5. Create Order");
            Console.WriteLine("6. Exit");
            Console.WriteLine("Enter your choice (1-6): ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    manager.AddItem();
                    break;
                case "2":
                    manager.RemoveItem();
                    break;
                case "3":
                    manager.DisplayItems();
                    break;
                case "4":
                    manager.CategorizeItem();
                    break;
                case "5":
                    manager.CreateOrder();
                    break;
                case "6":
                    exit = true;
                    Console.WriteLine("Exiting the system");
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }

    }
}