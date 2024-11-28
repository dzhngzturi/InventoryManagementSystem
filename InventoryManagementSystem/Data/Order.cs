using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Data
{
    public class Order
    {
        public int OrderID { get; set; }
        public List<OrderItem> OrderItems { get; set; }

        public double TotalAmount => CalculateTotal();

        private static int orderCounter = 1;

        public Order()
        {
            OrderID = orderCounter++;
            OrderItems = new List<OrderItem>();
        }

        public void AddItem(OrderItem orderItem)
        {
            OrderItems.Add(orderItem);
        }

        public double CalculateTotal()
        {
            double total = 0;
            foreach (var item in OrderItems)
            {
                total += item.ItemTotal;
            }

            return total;
        }

        public void UpdateInventory()
        {
            foreach (var orderItem in OrderItems)
            {
                var itemInventory = orderItem.Item;
                itemInventory.Quantity -= itemInventory.Quantity;
            }
        }

        public void DisplayOrderDetails()
        {
            Console.WriteLine($"Order ID: {OrderID}");
            Console.WriteLine($"Total Amount: {TotalAmount:C}");
            Console.WriteLine($"Items in order:");

            foreach (var orderItem in OrderItems)
            {
                Console.WriteLine(orderItem.Item.GetItemDetails());
            }
        }
    }
}
