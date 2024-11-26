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
        public string Category { get; set; }
        public DateTime ExpirationDate { get; set; }
        public AbstractItem(string name, double price, string category, DateTime dateTime)
        {
            this.Name = name;
            this.Price = price;
            this.Category = category;
            this.ExpirationDate = dateTime;
        }

        public virtual double CalculateValue()
        {
            return Price;
        }

        public virtual string GetItemDetails()
        {
            return $"Name: {Name}, Price: {Price}, Expiration Date: {ExpirationDate.ToShortDateString()}";
        }

        public virtual void ItemDescription()
        {
            Console.WriteLine($"Description: {Name}, Lorem Ipsum is simply dummy text of the printing and typesetting industry.");
        }
        public virtual string GetCategory()
        {
            return Category;
        }
        public virtual void SetCategory(string categoryName)
        {
            this.Category = categoryName;
        }

        public virtual bool IsBreakable()
        {
            return false;
        }

        public virtual void HandleBreakage()
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

        public virtual bool IsPerishable()
        {
            return ExpirationDate < DateTime.Now;
        }

        public virtual void HandleExpiration()
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

        public virtual double GetPrice()
        {
            return Price;
        }

        public virtual void SetPrice(double price)
        {
           Price = price;   
        }
    }
}
