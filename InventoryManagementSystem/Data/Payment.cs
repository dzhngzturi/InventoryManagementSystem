using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Data
{
    public class Payment
    {
        public double Amount { get; set; }
        public bool IsPaid { get; set; }
        public Payment(double amount)
        {
            Amount = amount;
            IsPaid = false;
        }

        public bool ProcessPayment(double total)
        {
            if (Amount >= total)
            {
                IsPaid = true;
                return true;
            }
            else
            {
                Console.WriteLine($"Payment cancelled order total is: {total:C} your card amount is: {Amount:C}");
                return false;
            }
        }
    }
}
