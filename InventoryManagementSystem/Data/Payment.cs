using InventoryManagementSystem.Interfaces;
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
        public Payment(double amount)
        {
            Amount = amount;
        }

        public bool ProcessPayment(IPaymentMethod paymentMethod, double orderTotal)
        {
            if (paymentMethod.Validate())
            {

                return paymentMethod.AuthorizePayment(orderTotal);
            }
            return false;

        }



    }
}
