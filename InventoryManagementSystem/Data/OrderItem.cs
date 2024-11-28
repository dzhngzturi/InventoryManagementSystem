using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Data
{
    public class OrderItem
    {
        public InventoryItem Item { get; set; }
        public int Quantity { get; set; }
        public double ItemTotal => Item.Price * Quantity;

        public OrderItem(InventoryItem item, int quantity)
        {
            Item = item;
            Quantity = quantity;
        }
    }
}
