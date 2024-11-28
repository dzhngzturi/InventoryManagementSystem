using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Data
{
    public class InventoryManager
    {
        public List<InventoryItem> Inventory { get; set; }
        public List<Order> Orders { get; set; }

        public InventoryManager()
        {
            Inventory = new List<InventoryItem>();
            Orders = new List<Order>();
        }

        public void SaveInventoryToFile(string fileName)
        {
            try
            {

                using (StreamWriter writer = new StreamWriter(fileName))
                {
                    foreach (var item in Inventory)
                    {
                        writer.WriteLine($"{item.ItemID}, {item.Name}, {item.Price}," +
                            $" {item.Category}, {item.ExpirationDate.ToShortDateString()}, {item.Quantity} ");
                    }
                }

                Console.WriteLine("Inventory saved to file");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving inventory: {ex.Message}");
            }
        }

        public void LoadInventoryFromFile(string fileName)
        {
            using (StreamReader reader = new StreamReader(fileName))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');

                    if (values.Length == 6)
                    {
                        int itemId = int.Parse(values[0]);
                        string name = values[1];
                        double price = double.Parse(values[2]);
                        string category = values[3];
                        DateTime expirationDate = DateTime.Parse(values[4]);
                        int quantity = int.Parse(values[5]);

                        var item = new InventoryItem(itemId, name, price, category, expirationDate, quantity);
                        Inventory.Add(item);
                    }
                }
            }

            Console.WriteLine($"Inventory loaded from file successfully");
        }

        public void AddItem()
        {
            Console.WriteLine("Enter Item ID:");
            int id = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Item Name:");
            string name = Console.ReadLine();

            Console.WriteLine("Enter Item Category:");
            string category = Console.ReadLine();

            Console.WriteLine("Enter Item Price");
            double price = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter Item Date (yyyy-mm-dd)");
            DateTime expirationDate = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Enter Item Quantity:");
            int quantity = int.Parse(Console.ReadLine());

            var item = new InventoryItem(id, name, price, category, expirationDate, quantity);
            Inventory.Add(item);
            Console.WriteLine("Item added successfully");
        }

        public void RemoveItem()
        {
            Console.WriteLine("Enter Item ID to remove:");
            int id = int.Parse(Console.ReadLine());

            var itemToRemove = Inventory.Find(item => item.ItemID == id);

            if (itemToRemove != null)
            {
                Inventory.Remove(itemToRemove);
                Console.WriteLine("Item removed succesfully");
            }
            else
            {
                Console.WriteLine("Item not found");
            }
        }

        public void DisplayItems()
        {
            if (Inventory.Count != 0)
            {
                Console.WriteLine("Inventory List");
                foreach (var item in Inventory)
                {
                    Console.WriteLine($"{item.ItemID} - {item.Name}, {item.Price:C}, {item.Category}, " +
                        $"Expiration: {item.ExpirationDate.ToShortDateString()},Quantity: {item.Quantity}");
                }
            }
            else
            {
                Console.WriteLine("Inventory is empty");
            }
        }

        public void CategorizeItem()
        {
            Console.WriteLine("Enter Item ID to categorize");
            int id = int.Parse(Console.ReadLine());

            var itemToCategorize = Inventory.Find(item => item.ItemID == id);
            if (itemToCategorize != null)
            {
                Console.WriteLine("Enter new category");
                string newCategory = Console.ReadLine();
                itemToCategorize.Category = newCategory;
                Console.WriteLine("item categorized successfully");
            }

            else { Console.WriteLine("Item not found"); }
        }

        public Order CreateOrder()
        {
            Order order = new Order();
            Console.WriteLine("Enter the number of items in the order");
            int numberOfItems = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfItems; i++)
            {
                Console.WriteLine($"Enter the item ID for item {i + 1}: ");
                int itemId = int.Parse(Console.ReadLine());
                var item = Inventory.Find(x => x.ItemID == itemId);
                if (item == null) {
                    Console.WriteLine("item not found");
                    continue;
                }
                Console.WriteLine($"Enter quantity for: {item.Name}");
                int quantity = int.Parse(Console.ReadLine());

                if (quantity > item.Quantity)
                {
                    Console.WriteLine("Not enough stock available");
                    continue;
                }

                order.AddItem(new OrderItem(item, quantity));
            }

            return order;
        }

        public void ProcessOrderPayment(Order order)
        {
            Console.WriteLine($"The total amount for the order is: {order.TotalAmount:C}");
            Console.WriteLine("Enter payment amount");
            double paymentAmount = double.Parse(Console.ReadLine());

            Payment payment = new Payment(paymentAmount);

            if (payment.ProcessPayment(order.TotalAmount))
            {
                Console.WriteLine("Payment successfull");
                order.UpdateInventory();
                Orders.Add(order);
            }
            else
            {
                Console.WriteLine("Payment failed. Please try again!");
            }
        }

    }
}
