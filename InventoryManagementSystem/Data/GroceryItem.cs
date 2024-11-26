using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Data
{
    public class GroceryItem: InventoryItem
    {
        public bool IsPerishable { get; set; }
        public GroceryItem(int itemId, string name, double price, string category, DateTime expirationDate
            , int quantity, bool isPerishable) : base(itemId, name, price, category, expirationDate, quantity)
        {
                IsPerishable = isPerishable;
        }


        public override double CalculateValue()
        {
            double baseValue = base.CalculateValue();

            if (IsPerishable && ExpirationDate <= DateTime.Now.AddDays(5))
            {
            // Adding a 10% off for near expiration perishable items :D
                return baseValue * 0.90d;
            }

            return baseValue;
        }

        public override string GetItemDetails()
        {
            return base.GetItemDetails() + $", Perishable: {IsPerishable}";
        }
    }
}
