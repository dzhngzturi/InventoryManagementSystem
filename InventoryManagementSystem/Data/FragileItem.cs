using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Data
{
    public class FragileItem : InventoryItem
    {
        public double Weight { get; set; }

        public FragileItem(int itemId, string name, double price, string category, DateTime expirationDate,
            int quantity, double weight) 
            : base(itemId, name, price, category, expirationDate, quantity)
        {
                Weight = weight;
        }

        public override double CalculateValue()
        {
            double baseValue = base.CalculateValue();

           // Adding a surcharge based on the weight of the fragile item, 5 BGN per kilogram
            double weightSurcharge = Weight * 5.00d;

            return baseValue + weightSurcharge;
        }

        public override string GetItemDetails()
        {
            return base.GetItemDetails() + $", Weight: {Weight} kg";
        }
    }
}
