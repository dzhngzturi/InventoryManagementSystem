using InventoryManagementSystem.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Data
{
    public class AbstractItem : IItem, ICategorizable, IBreakable, IPerishable, ISellable
    {
        public string Name {  get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public string Category { get; set; }
        public DateTime ExpirationDate { get; set; }
        public AbstractItem(string name, double price, int quantity, string category, DateTime dateTime)
        {
            this.Name = name;
            this.Price = price;
            this.Quantity = quantity;
            this.Category = category;
            this.ExpirationDate = dateTime;
        }

        public double CalculateValue()
        {
            return Quantity * Price;
        }

        public string GetItemDetails()
        {
            return $"Name: {Name}, Price: {Price}, Quantity: {Quantity}, Expiration Date: {ExpirationDate.ToShortDateString()}";
        }

        public void ItemDescription()
        {
            Console.WriteLine($"Description: {Name}, Lorem Ipsum is simply dummy text of the printing and typesetting industry.");
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
            return false;
        }

        public void HandleBreakage()
        {
            if (IsBreakable())
            {
                Console.WriteLine($"{Name} has broken");
            }
            else
            {
                Console.WriteLine($"{Name} is not breakable");
            }
        }

        public bool IsPerishable()
        {
            return ExpirationDate < DateTime.Now;
        }

        public void HandleExpiration()
        {
            if (!IsPerishable())
            {
                Console.WriteLine($"{Name} has expired {ExpirationDate.ToShortDateString()}");
            }
            else
            {
                Console.WriteLine($"{Name} is still fresh");
            }
        }

        public double GetPrice()
        {
            return Price;
        }

        public void SetPrice(double price)
        {
           Price = price;   
        }
    }
}
