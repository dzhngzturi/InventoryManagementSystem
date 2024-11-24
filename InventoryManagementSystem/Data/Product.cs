using InventoryManagementSystem.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Data
{
    public class Product : IItem, ICategorizable, IBreakable, IPerishable, ISellable
    {
        private string name;
        private string category;
        private double price;
        private int quantity;
        private bool isBreakable;
        private bool isPerishable;
        private string expirationDate;

        public Product(string name, double price, int quantity, bool isBreakable, string expirationDate)
        {
            this.name = name;
            this.price = price;
            this.quantity = quantity;
            this.isBreakable = isBreakable;
            this.expirationDate = expirationDate;
        }


        public string GetItemDetails()
        {
            return ($"Product Name: {name}, Price: {price}");
        }

        public double CalculateValue()
        {
            return price * quantity;
        }

        public void ItemDescription()
        {
            Console.WriteLine($"Product description: {name}, Lorem Ipsum is simply dummy text of the printing and typesetting industry. ");
        }
        public string GetCategory()
        {
            return category;
        }

        public void SetCategory(string categoryName)
        {
            this.category = categoryName;
        }

        public bool IsBreakable()
        {
            return isBreakable;
        }

        public void HandleBreakage()
        {
            if (isBreakable)
            {
                Console.WriteLine($"{name} has been broken and can't be sold");
            }
        }

        public bool IsPerishable()
        {
            return !string.IsNullOrEmpty(expirationDate);
        }

        public void HandleExpiration()
        {
            Console.WriteLine($"{name} has expired and can't be sold");
        }

        public double GetPrice()
        {
            return price;
        }

        public void SetPrice(double price)
        {
            this.price = price;
        }
    }
}
