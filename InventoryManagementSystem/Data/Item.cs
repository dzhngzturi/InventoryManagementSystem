using InventoryManagementSystem.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Data
{
    public class Item : IItem, ICategorizable
    {
        private string name;
        private double price;
        private int quantity;
        private string category;
        public Item(string name, double price, int quantity)
        {
            this.name = name;
            this.price = price;
            this.quantity = quantity;
        }

        public double CalculateValue()
        {
            return quantity * price;
        }

        public string GetItemDetails()
        {
            return $"Name: {name}, Price: {price}, Quantity: {quantity}";
        }

        public void ItemDescription()
        {
            Console.WriteLine($"Description: {name}, Lorem Ipsum is simply dummy text of the printing and typesetting industry.");
        }
        public string GetCategory()
        {
            return category;
        }
        public void SetCategory(string categoryName)
        {
            this.category = categoryName;
        }
    }
}
