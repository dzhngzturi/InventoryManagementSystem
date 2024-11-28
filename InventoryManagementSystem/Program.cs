using InventoryManagementSystem.Data;
using InventoryManagementSystem.Interfaces;

public class Program
{
    private static void Main(string[] args)
    {
        InventoryManager manager = new InventoryManager();

        bool exit = false;

        manager.Inventory.Add(new InventoryItem(01, "Iphone 14 Pro Max", 2000, "Electronics", DateTime.Now.AddYears(1), 12));
        manager.Inventory.Add(new InventoryItem(02, "Milk", 3, "Grocery", DateTime.Now.AddDays(6), 10));


        while (!exit)
        {
            Console.WriteLine("Inventory Management System");
            Console.WriteLine("1. Add item");
            Console.WriteLine("2. Remove item by ID");
            Console.WriteLine("3. Display items");
            Console.WriteLine("4. Create Order");
            Console.WriteLine("5. Process Payment");
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
                    Order order = manager.CreateOrder();
                    // Console.WriteLine($"Order created with with Order ID is: {order.OrderID} and total is: {order.TotalAmount:C}");
                    order.DisplayOrderDetails();
                    break;
                case "5":
                    Console.WriteLine("Enter the Order ID to proccess for payment");
                    int orderId = int.Parse(Console.ReadLine()); 

                    Order orderToProcess = manager.Orders.Find(o => o.OrderID == orderId);
                    if (orderToProcess != null)
                    {
                        manager.ProcessOrderPayment(orderToProcess);
                    }
                    else
                    {
                        Console.WriteLine("Order not found");
                    }
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