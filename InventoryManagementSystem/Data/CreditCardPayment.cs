using InventoryManagementSystem.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Data
{
    public class CreditCardPAyment : IPaymentMethod
    {
        public string CardNumber { get; set; }
        public string ExpirationDate { get; set; }
        public string CCV { get; set; }
        public CreditCardPAyment(string cardNumber, string expirationDate, string ccv)
        {
            CardNumber = cardNumber;
            ExpirationDate = expirationDate;
            CCV = ccv;
        }
        public bool AuthorizePayment(double amount)
        {
            Console.WriteLine($"Proccessing payment of {amount:C} with credit card ending in {CardNumber.Substring(CardNumber.Length - 4)}");
            return true;
        }

        public bool Validate()
        {
            return !string.IsNullOrEmpty(CardNumber) && CardNumber.Length == 16 && !string.IsNullOrEmpty(CCV);
        }
    }
}
