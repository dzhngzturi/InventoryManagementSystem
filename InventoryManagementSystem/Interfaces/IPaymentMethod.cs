using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Interfaces
{
    public interface IPaymentMethod
    {
        bool Validate();
        bool AuthorizePayment(double amount);
    }
}
