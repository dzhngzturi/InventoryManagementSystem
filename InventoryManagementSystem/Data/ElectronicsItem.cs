using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Data
{
    public class ElectronicsItem : InventoryItem
    {
        public int WarrantyPeriod { get; set; }
        public ElectronicsItem(int itemId, string name, double price, string category, DateTime expirationDate, int quantity, int warrantyPeriod)
            : base(itemId, name, price, category, expirationDate, quantity)
        {
            WarrantyPeriod = warrantyPeriod;
        }

        public override double CalculateValue()
        {
            double baseValue = base.CalculateValue();
            // Adding a 10% for each year of warenty
            double warrantyMultiplier = 1 + (WarrantyPeriod / 12) * 0.10d;
            return baseValue * warrantyMultiplier;
        }

        public override string GetItemDetails()
        {
            return base.GetItemDetails() + $", Warranty Period: {WarrantyPeriod} months";
        }
    }
}
