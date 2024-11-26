using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Data
{
    public class InventoryItem : AbstractItem
    {
        public int ItemID { get; set; }
        public int Quantity { get; set; }


        public InventoryItem(int itemId, string name, double price, string category, DateTime expirationDate, int quantity)
            : base(name, price, category, expirationDate)
        {
            ItemID = itemId;
            Quantity = quantity;
        }

        public int GetItemID()
        {
            return ItemID;
        }

        public void SetItemID(int id)
        {
            ItemID = id;
        }

        public int GetQuantity()
        {
            return Quantity;
        }

        public void SetQuantity(int quantity)
        {
            Quantity = quantity;
        }

        public override string GetItemDetails()
        {
            return base.GetItemDetails() + ($", ID: {ItemID}, Quantity: {Quantity}");
        }

        public void AdjustQuantity(int amount)
        {
            Quantity += amount;
            if (Quantity < 0) Quantity = 0;
        }

        public override double CalculateValue()
        {
            double baseValue = base.GetPrice();
            return baseValue * Quantity;
        }
    }
}
