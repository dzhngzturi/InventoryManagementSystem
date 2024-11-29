using InventoryManagementSystem.Interfaces;
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
        public double Discount { get; set; }
        public double OrderTotal { get; set; }

        public double TotalAmount
        {
            get
            {
                CalculateOrderTotal();
                return OrderTotal;
            }
        }

        private static int orderCounter = 1;

        public Order()
        {
            OrderID = orderCounter++;
            OrderItems = new List<OrderItem>();
            Discount = 0;
            OrderTotal = 0;
        }

        public void AddItem(InventoryItem  item, int quantity)
        {
            OrderItems.Add(new OrderItem(item, quantity));

            item.Quantity -= quantity;

            Console.WriteLine($"Item {item.Name} with quantity {quantity} added to the order.");
        }

        public void CalculateOrderTotal()
        {
            OrderTotal = OrderItems.Sum(i => i.InventoryItem.GetPrice() * i.Quantity);
            OrderTotal -= Discount;
        }

        public void UpdateInventory()
        {
            foreach (var orderItem in OrderItems)
            {
                var itemInventory = orderItem.InventoryItem;
                itemInventory.Quantity -= itemInventory.Quantity;
                Console.WriteLine($"Updated inventory for {itemInventory.Name}: {itemInventory.Quantity} remaining.");
            }
        }

        public void ApplyDiscount(string discountCode)
        {
            if (discountCode == "discount10")
            {
                Discount = OrderTotal * 0.10;
                Console.WriteLine("Discount applied: 10%");
            }
            else
            {
                Console.WriteLine("Discount code invalid");
            }
            CalculateOrderTotal();
        }

        public void ConfirmOrder()
        {
            foreach (var orderItem in OrderItems)
            {
                orderItem.InventoryItem.Quantity -= orderItem.Quantity;
            }

            Console.WriteLine($"Order #{OrderID} confirmed.");
        }

        public void DisplayOrderDetails()
        {
            Console.WriteLine($"Order ID:{OrderID}");
            Console.WriteLine($"Total Amount: {TotalAmount:C}");
            Console.WriteLine($"Items in order:");

            foreach (var orderItem in OrderItems)
            {
                Console.WriteLine($"{orderItem.InventoryItem.Name} x {orderItem.Quantity} = {orderItem.InventoryItem.Price * orderItem.Quantity:C}");
            }
        }
    }
}
