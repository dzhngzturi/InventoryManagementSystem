using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Data
{
    public class OrderItem
    {
        public InventoryItem InventoryItem { get; set; }
        public int Quantity { get; set; }

        public OrderItem(InventoryItem inventoryItem, int quantity)
        {
            InventoryItem = inventoryItem;
            Quantity = quantity;
        }


    }
}
