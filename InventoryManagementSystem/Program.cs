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
        manager.Inventory.Add(new InventoryItem(03, "Glass Table", 3, "Fragile", DateTime.Now.AddMonths(10), 250));
        manager.Inventory.Add(new InventoryItem(04, "Window", 3, "Fragile", DateTime.Now.AddYears(5), 200));

        Console.WriteLine("Searching for grocery item");
        var grocery = manager.SearchByName("Grocery");
        foreach (var item in grocery)
        {
            Console.WriteLine($"{item.Name} - {item.Category} - {item.Price:C}");
        }

        Console.WriteLine("Searching for fragile category:");
        var fragile = manager.SearchByCategory("Fargile");
        foreach (var item in fragile)
        {
            Console.WriteLine($"{item.Name} - {item.Category} - {item.Price:C}");
        }


        while (!exit)
        {
            Console.WriteLine("Inventory Management System");
            Console.WriteLine("1. Add item");
            Console.WriteLine("2. Remove item by ID");
            Console.WriteLine("3. Display items");
            Console.WriteLine("4. Create Order");
            Console.WriteLine("5. Process Payment");
            Console.WriteLine("6. Display Orders");
            Console.WriteLine("7. Exit");
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
                        Console.WriteLine("Choose a payment method:");
                        Console.WriteLine("1. Credit Card");
                        Console.WriteLine("2. PayPal");
                        string paymentChoice = Console.ReadLine();
                        IPaymentMethod paymentMethod = null;

                        switch (paymentChoice)
                        {
                            case "1":
                                Console.WriteLine("Enter credit card number:");
                                string cardNumber = Console.ReadLine();
                                Console.WriteLine("Enter expiration date (MM/YY):");
                                string expirationDate = Console.ReadLine();
                                Console.WriteLine("Enter CVV:");
                                string cvv = Console.ReadLine();
                                paymentMethod = new CreditCardPAyment(cardNumber, expirationDate, cvv);
                                break;
                            case "2":
                                Console.WriteLine("Enter PayPal account email:");
                                string payPalEmail = Console.ReadLine();
                                paymentMethod = new PayPalPayment(payPalEmail);
                                break;
                            default:
                                Console.WriteLine("Invalid payment method choice.");
                                break;
                        }

                        if (paymentMethod != null)
                        {
                            manager.ProcessOrderPayment(orderToProcess, paymentMethod);
                        }
                        else
                        {
                            Console.WriteLine("No valid payment method selected. Returning to main menu.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Order not found");
                    }
                    break;
                case "6":
                    manager.DisplayOrders();
                    break;
                case "7":
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