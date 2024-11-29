using InventoryManagementSystem.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Data
{
    public class PayPalPayment : IPaymentMethod
    {
        public string PayPalAccount { get; set; }
        public PayPalPayment(string paypalAccount)
        {
            PayPalAccount = paypalAccount;
        }
        public bool AuthorizePayment(double amount)
        {
            Console.WriteLine($"Proccessing PayPal payment of {amount:C} for acount {PayPalAccount} ...");
            return true;
        }

        public bool Validate()
        {
            return !string.IsNullOrEmpty(PayPalAccount) && PayPalAccount.Contains("@");
        }
    }
}
