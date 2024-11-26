using InventoryManagementSystem.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Data
{
    public class Product : AbstractItem
    {
        public Product(string name, double price, string category, DateTime expirationDate) :
            base(name, price, category, expirationDate)
        {

        }


        public string GetItemDetails()
        {
            return ($"Product Name: {Name}, Price: {Price}");
        }

        public double CalculateValue()
        {
            return Price;
        }

        public void ItemDescription()
        {
            Console.WriteLine($"Product description: {Name}, Lorem Ipsum is simply dummy text of the printing and typesetting industry. ");
        }
        public string GetCategory()
        {
            return Category;
        }

        public void SetCategory(string categoryName)
        {
            this.Category = categoryName;
        }

        public bool IsBreakable()
        {
            return true;
        }

        public void HandleBreakage()
        {

            Console.WriteLine($"{Name} has been broken and can't be sold");
        }

        public bool IsPerishable()
        {
            return !string.IsNullOrEmpty(ExpirationDate.ToShortDateString());
        }

        public void HandleExpiration()
        {
            Console.WriteLine($"{Name} has expired and can't be sold");
        }

        public double GetPrice()
        {
            return Price;
        }

        public void SetPrice(double price)
        {
            this.Price = price;
        }
    }
}
